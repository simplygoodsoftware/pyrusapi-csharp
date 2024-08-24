using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;
using Pyrus.ApiClient.Requests;
using Pyrus.ApiClient.Responses;
using PyrusApiClient;
using PyrusApiClient.Exceptions;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

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
					catch
					{
						if (i == client.ClientSettings.RetryCount)
							throw;
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

				var response = await RetryGetTokenAsync(client, url);
				var result = JsonConvert.DeserializeObject<AuthResponse>(response.Message);
				if (result.AccessToken == null)
					return false;

				client.Token = result.AccessToken;

				SetOrigins(client, result);

				return true;
			}
			catch (Exception e)
			{
				throw new PyrusApiClientException(e.Message, e);
			}
		}

		private static async Task<MessageWithStatusCode> RetryGetTokenAsync(PyrusClient client, string url)
		{
			for (var i = 0; i <= client.ClientSettings.RetryCount; i++)
			{
				try
				{
					var response = await RequestHelper.PostRequest(client, url, new AuthRequest() { Login = client.Login, SecurityKey = client.SecretKey, PersonId = client.PersonId });
					return response;
				}
				catch (HttpRequestException e)
				{
					if (i == client.ClientSettings.RetryCount)
						throw;
				}
				catch (WebException e)
				{
					if (i == client.ClientSettings.RetryCount)
						throw;
				}
				catch (TaskCanceledException e)
				{
					if (i == client.ClientSettings.RetryCount)
						throw;
				}
			}

			return null;
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
	}
}
