using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;
using Pyrus.ApiClient.Requests;
using Pyrus.ApiClient.Responses;
using PyrusApiClient;
using PyrusApiClient.Exceptions;

namespace Pyrus.ApiClient
{
	internal static class ClientExtensions
	{
		private static readonly TimeSpan DefaultRetryTimeout = TimeSpan.FromMilliseconds(200);

		public static async Task<TResponse> RunQuery<TResponse>(this PyrusClient client, Func<Task<MessageWithStatusCode>> action) where TResponse : ResponseBase
		{
			try
			{
				var result = default(TResponse);
				for (var i = 0; i <= client.ClientSettings.RetryCount; i++)
				{
					if (i > 0)
						await System.Threading.Tasks.Task.Delay(DefaultRetryTimeout);

					var res = await action();
					if (res == null)
						continue;

					if (typeof(TResponse) == typeof(DownloadResponse))
						return CreateDownloadResponse<TResponse>(res);

					if (typeof(TResponse) == typeof(FormRegisterResponse) && res.ToCsv)
						return new FormRegisterResponse { Csv = res.Message } as TResponse;

					try
					{
						result = JsonConvert.DeserializeObject<TResponse>(res.Message, new FormFieldJsonConverter());
					}
					catch (Exception ex)
					{
						if (i == client.ClientSettings.RetryCount)
						{
							ThrowIfResponseHtml(res, ex);
							throw;
						}
						continue;
					}

					if (typeof(TResponse) == typeof(ResponseBase)
						&& result is null
						&& res.StatusCode == HttpStatusCode.OK)
						return result;

					if (result is null)
						continue;

					if (result.Error != null)
					{
						if (res.StatusCode != HttpStatusCode.Unauthorized || i == client.ClientSettings.RetryCount)
							continue;

						var isValidParameters = await client.GetTokenAsync();
						if (!isValidParameters)
							return result;
					}
					else
					{
						break;
					}
				}

				return result;
			}
			catch (Exception e)
			{
				throw new PyrusApiClientException(e.Message, e);
			}
		}

		internal static async Task<TResponse> RunQuery<TResponse>(this PyrusClient client,
			Func<Task<MessageWithStatusCode>> action, bool safeRetry, CancellationToken cancellationToken)
			where TResponse : ResponseBase, new()
		{
			var timer = Stopwatch.StartNew();
			var refreshed = false;
			var retries = 0;
			try
			{
				if (string.IsNullOrEmpty(client.Token))
					await client.GetTokenAsync(cancellationToken).ConfigureAwait(false);

				while (true)
				{
					cancellationToken.ThrowIfCancellationRequested();
					if (timer.Elapsed >= TimeSpan.FromMinutes(5))
						throw new InvalidOperationException("The retry window expired; the command outcome is unknown.");

					MessageWithStatusCode response;
					try
					{
						response = await action().ConfigureAwait(false);
					}
					catch (Exception error) when ((error is HttpRequestException || error is IOException || error is TaskCanceledException)
						&& !cancellationToken.IsCancellationRequested && safeRetry && retries < client.ClientSettings.RetryCount)
					{
						await RetryDelayAsync(timer, TimeSpan.FromMilliseconds(200 * Math.Pow(2, retries++)), cancellationToken).ConfigureAwait(false);
						continue;
					}

					if (response.StatusCode == HttpStatusCode.Unauthorized && !refreshed)
					{
						refreshed = true;
						if (await client.GetTokenAsync(cancellationToken).ConfigureAwait(false))
						{
							response.Content?.Dispose();
							continue;
						}
					}

					if (((int)response.StatusCode == 429 || (safeRetry && (int)response.StatusCode >= 500))
						&& retries < client.ClientSettings.RetryCount)
					{
						var delay = response.RetryAfter ?? TimeSpan.FromMilliseconds(200 * Math.Pow(2, retries));
						retries++;
						response.Content?.Dispose();
						await RetryDelayAsync(timer, delay < TimeSpan.Zero ? TimeSpan.Zero : delay, cancellationToken).ConfigureAwait(false);
						continue;
					}

					if (typeof(TResponse) == typeof(DownloadResponse) && (response.Content != null || (int)response.StatusCode < 400))
						return CreateDownloadResponse<TResponse>(response);

					TResponse result;
					try
					{
						result = JsonConvert.DeserializeObject<TResponse>(response.Message, new FormFieldJsonConverter()) ?? new TResponse();
					}
					catch (JsonException error)
					{
						ThrowIfResponseHtml(response, error);
						throw;
					}
					if ((int)response.StatusCode >= 400 && result.Error == null)
					{
						result.Error = "Request failed (HTTP " + (int)response.StatusCode + ").";
						result.ErrorCode = ErrorCodeType.ServerError;
					}
					return result;
				}
			}
			catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
			{
				throw;
			}
			catch (PyrusApiClientException)
			{
				throw;
			}
			catch (Exception error)
			{
				throw new PyrusApiClientException(error.Message, error);
			}
		}

		private static System.Threading.Tasks.Task RetryDelayAsync(Stopwatch timer, TimeSpan delay, CancellationToken cancellationToken)
		{
			if (timer.Elapsed + delay >= TimeSpan.FromMinutes(5))
				throw new InvalidOperationException("The retry window expired; the command outcome is unknown.");
			return System.Threading.Tasks.Task.Delay(delay, cancellationToken);
		}

		private static TResponse CreateDownloadResponse<TResponse>(MessageWithStatusCode res) where TResponse : ResponseBase
		{
			var resp = new DownloadResponse
			{
				Content = res.Content,
				FileName = res.FileName
			};

			if (res.StatusCode == HttpStatusCode.Forbidden || res.StatusCode == HttpStatusCode.Gone)
				resp.ErrorCode = ErrorCodeType.AccessDeniedFile;
			else if (res.StatusCode == HttpStatusCode.NotFound)
				resp.ErrorCode = ErrorCodeType.FileIsMissing;
			else if (res.StatusCode == HttpStatusCode.Unauthorized)
				resp.ErrorCode = ErrorCodeType.AuthorizationError;
			else if (res.StatusCode != HttpStatusCode.OK)
				resp.ErrorCode = ErrorCodeType.ServerError;

			return resp as TResponse;
		}

		private static async Task<bool> GetTokenAsync(this PyrusClient client, CancellationToken cancellationToken = default)
		{
			try
			{
				var url = GetAuthUrl(client);

				var response = await RequestHelper.PostRequest(client, url,
					new AuthRequest() { Login = client.Login, SecurityKey = client.SecretKey, PersonId = client.PersonId }, cancellationToken: cancellationToken);
				var result = JsonConvert.DeserializeObject<AuthResponse>(response.Message);
				if (result.AccessToken == null)
					return false;

				client.Token = result.AccessToken;

				SetOrigins(client, result);

				return true;
			}
			catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
			{
				throw;
			}
			catch (Exception e)
			{
				throw new PyrusApiClientException(e.Message, e);
			}
		}

		internal static string GetAuthUrl(PyrusClient client)
		{
			// if is default API origin or custom auth origin
			if (string.Equals(client.ClientSettings.Origin, Settings.PyrusOrigin)
				|| !string.Equals(client.ClientSettings.AuthOrigin, Settings.PyrusAuthOrigin))
			{
				return client.ClientSettings.AuthOrigin + PyrusClient.AuthEndpoint;
			}

			return client.ClientSettings.Origin + PyrusClient.AuthEndpoint;
		}

		internal static void SetOrigins(PyrusClient client, AuthResponse response)
		{
			if (!string.IsNullOrEmpty(response.FilesUrl))
			{
				client.ClientSettings.FilesOrigin = response.FilesUrl;
			}

			if (!string.IsNullOrEmpty(response.ApiUrl))
			{
				client.ClientSettings.Origin = response.ApiUrl;
			}
		}

		private static void ThrowIfResponseHtml(MessageWithStatusCode response, Exception exception)
		{
			if (!(exception is JsonReaderException))
				return;

			if (response?.Message == null)
				return;

			if (!response.Message.StartsWith("<", StringComparison.Ordinal))
				return;

			var message = $"Invalid server response: {response.ResponseDescription}, Response content: {response.Message}";
			throw new InvalidServerResponseException(message, exception);
		}
	}
}
