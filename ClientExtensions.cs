using System;
using System.CodeDom;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;
using Pyrus.ApiClient.Responses;
using PyrusApiClient;
using PyrusApiClient.Exceptions;

namespace Pyrus.ApiClient
{
	internal static class ClientExtensions
	{
		public static async Task<TResponse> RunQuery<TResponse>(this PyrusClient client, Func<Task<MessageWithStatusCode>> action) where TResponse : ResponseBase
		{
			try
			{
				var result = default(TResponse);
				for (var i = 0; i < PyrusClient.Settings.RetryCount; i++)
				{
					var res = await action();
					if (res == null)
						continue;

					if (typeof(TResponse) == typeof(DownloadResponse))
						return CreateDownloadResponse<TResponse>(res);
					if (typeof(TResponse) == typeof(FormRegisterResponse) && res.ToCsv)
						return (await CreateCsvResponse(res)) as TResponse;

					result = JsonConvert.DeserializeObject<TResponse>(res.Message, new FormFieldJsonConverter());
					if (result == null)
						continue;

					if (result.Error != null)
					{
						if (res.StatusCode != HttpStatusCode.Unauthorized || i == PyrusClient.Settings.RetryCount - 1)
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

		private static async Task<FormRegisterResponse> CreateCsvResponse(MessageWithStatusCode res)
		{
			using (var reader = new StreamReader(res.Content, res.Encoding))
			{
				var csv = await reader.ReadToEndAsync();
				return new FormRegisterResponse
				{
					Csv = csv
				};
			}
		}

		private static TResponse CreateDownloadResponse<TResponse>(MessageWithStatusCode res) where TResponse : ResponseBase
		{
			var resp = new DownloadResponse
			{
				Content = res.Content,
				FileName = res.FileName
			};

			if (res.StatusCode == HttpStatusCode.Forbidden || res.StatusCode == HttpStatusCode.NotFound)
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
				var url = PyrusClient.Settings.Origin + PyrusClient.AuthEndpoint + $"/?login={client.Login}&security_key={client.SecretKey}";

				var response = await RequestHelper.GetRequest(url);
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
