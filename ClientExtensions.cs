using System;
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

		internal static Task<TResponse> RunChatQueryAsync<TResponse>(this PyrusClient client,
			HttpMethod method, string path, string payload, string accessToken, CancellationToken cancellationToken)
			where TResponse : ResponseBase
			=> client.RunChatQueryAsync<TResponse>(
				(apiOrigin, _, token) => RequestHelper.SendRequest(client, method, apiOrigin + path, payload, token, cancellationToken),
				accessToken, cancellationToken);

		internal static async Task<TResponse> RunChatQueryAsync<TResponse>(this PyrusClient client,
			Func<string, string, string, Task<MessageWithStatusCode>> action, string accessToken, CancellationToken cancellationToken)
			where TResponse : ResponseBase
		{
			var previous = client.CurrentToken;
			var token = accessToken ?? previous?.Value;
			var apiOrigin = client.ClientSettings.Origin;
			var filesOrigin = client.ClientSettings.FilesOrigin;
			var credentials = accessToken == null ? previous?.Credentials : null;
			var authUrl = previous?.AuthUrl;

			try
			{
				cancellationToken.ThrowIfCancellationRequested();
				if (accessToken == null && string.IsNullOrEmpty(token))
				{
					credentials = GetCredentials(client);
					authUrl = GetAuthUrl(client);
					if (!await RefreshTokenAsync().ConfigureAwait(false))
						credentials = null;
				}

				var response = await action(apiOrigin, filesOrigin, token).ConfigureAwait(false);
				if (response.StatusCode == HttpStatusCode.Unauthorized && credentials != null
					&& await RefreshTokenAsync().ConfigureAwait(false))
				{
					response.Content?.Dispose();
					response = await action(apiOrigin, filesOrigin, token).ConfigureAwait(false);
				}

				if (typeof(TResponse) == typeof(DownloadResponse) && string.IsNullOrEmpty(response.Message))
					return CreateDownloadResponse<TResponse>(response);

				try
				{
					return JsonConvert.DeserializeObject<TResponse>(response.Message, new FormFieldJsonConverter());
				}
				catch (JsonException error)
				{
					ThrowIfResponseHtml(response, error);
					throw;
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

			async Task<bool> RefreshTokenAsync()
			{
				var response = await RequestTokenAsync(client, authUrl, credentials, cancellationToken).ConfigureAwait(false);
				if (string.IsNullOrEmpty(response?.AccessToken))
					return false;

				token = response.AccessToken;
				if (!string.IsNullOrEmpty(response.ApiUrl))
					apiOrigin = response.ApiUrl.TrimEnd('/');
				if (!string.IsNullOrEmpty(response.FilesUrl))
					filesOrigin = response.FilesUrl.TrimEnd('/');

				var updated = new PyrusClient.TokenState(token, credentials, authUrl);
				if (client.TryUpdateToken(previous, updated))
				{
					previous = updated;
					SetOrigins(client, response);
				}
				return true;
			}
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

		private static async Task<bool> GetTokenAsync(this PyrusClient client)
		{
			try
			{
				var url = GetAuthUrl(client);
				var credentials = GetCredentials(client);
				var result = await RequestTokenAsync(client, url, credentials, CancellationToken.None).ConfigureAwait(false);
				if (result.AccessToken == null)
					return false;

				client.CurrentToken = new PyrusClient.TokenState(result.AccessToken, credentials, url);

				SetOrigins(client, result);

				return true;
			}
			catch (Exception e)
			{
				throw new PyrusApiClientException(e.Message, e);
			}
		}

		private static AuthRequest GetCredentials(PyrusClient client)
			=> new AuthRequest { Login = client.Login, SecurityKey = client.SecretKey, PersonId = client.PersonId };

		private static async Task<AuthResponse> RequestTokenAsync(PyrusClient client,
			string url, AuthRequest credentials, CancellationToken cancellationToken)
		{
			var response = await RequestHelper.PostRequest(client, url, credentials, cancellationToken: cancellationToken).ConfigureAwait(false);
			return JsonConvert.DeserializeObject<AuthResponse>(response.Message);
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
