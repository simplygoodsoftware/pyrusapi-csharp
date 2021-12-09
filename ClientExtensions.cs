using System;
using System.Net;
using System.Net.Http;
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
					catch
					{
						if (i == client.ClientSettings.RetryCount)
							throw;
						continue;
					}

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

			if (res.StatusCode == HttpStatusCode.Forbidden || res.StatusCode == HttpStatusCode.NotFound || res.StatusCode == HttpStatusCode.Gone)
				resp.ErrorCode = ErrorCodeType.AccessDeniedFile;
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
				var url = client.ClientSettings.Origin + PyrusClient.AuthEndpoint;

				var response = await RequestHelper.PostRequest(client, url, new AuthRequest() { Login = client.Login, SecurityKey = client.SecretKey });
				var result = JsonConvert.DeserializeObject<AuthResponse>(response.Message);
				if (result.AccessToken == null)
					return false;

				client.Token = result.AccessToken;
				return true;
			}
			catch (Exception e)
			{
				throw new PyrusApiClientException(e.Message, e);
			}
		}
	}
}
