using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;
using Pyrus.ApiClient.Responses;
using PyrusApiClient.Exceptions;

namespace PyrusApiClient
{
	internal class RequestHelper
	{
		public PyrusClient PyrusClient { get; set; }

		public RequestHelper(PyrusClient cient)
		{
			PyrusClient = cient;
		}

		public string CurrentVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

		private string UserAgent =>
			$"PyrusApiClient/{CurrentVersion} ({Environment.OSVersion}; {(Environment.Is64BitOperatingSystem ? "x64" : "x32")})";

		internal async Task<MessageWithStatusCode> PostRequest(string url, object request, string token = null)
		{
			using (var httpClient = PyrusClient.Settings.NewHttpClient())
			{
				SetHeaders(httpClient, token, UserAgent);
				using (var response = await httpClient.PostAsync(url,
					new StringContent(
						JsonConvert.SerializeObject(request,
							new JsonSerializerSettings
							{
								NullValueHandling = NullValueHandling.Ignore,
								DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
								Converters = new List<JsonConverter> { new FormRegisterRequestJsonConverter() }
							}),
						Encoding.UTF8, "application/json")))
				{
					var message = await response.Content.ReadAsStringAsync();
					return new MessageWithStatusCode { Message = message, StatusCode = response.StatusCode };
				}
			}
		}

		internal async Task<MessageWithStatusCode> PostFileRequest(string url, Stream fileStream, string fileName, string token)
		{
			using (var httpClient = PyrusClient.Settings.NewHttpClient())
			{
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
				httpClient.DefaultRequestHeaders.Add("ContentType", "multipart/form-data");
				httpClient.DefaultRequestHeaders.Add("User-Agent", UserAgent);

				var streamContent = new StreamContent(fileStream);
				streamContent.Headers.Add("Content-Type", "application/octet-stream");
				var header = $"form-data; name=\"file\"; filename=\"{fileName}\"";
				var bytes = Encoding.UTF8.GetBytes(header);
				header = bytes.Aggregate("", (current, b) => current + (char) b);
				streamContent.Headers.Add("Content-Disposition", header);

				var multipart = new MultipartFormDataContent {{streamContent, "file", $"{fileName}"}};
				using (var response = await httpClient.PostAsync(url, multipart))
				{
					var message = await response.Content.ReadAsStringAsync();
					return new MessageWithStatusCode { Message = message, StatusCode = response.StatusCode };
				}
			}
		}

		internal async Task<MessageWithStatusCode> GetFileRequest(string url, string token)
		{
			using (var httpClient = PyrusClient.Settings.NewHttpClient())
			{
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
				httpClient.DefaultRequestHeaders.Add("User-Agent", UserAgent);

				using (var response = await httpClient.GetAsync(url))
				{
					var result = new MessageWithStatusCode { StatusCode = response.StatusCode };
					if (response.StatusCode == HttpStatusCode.OK)
					{
						result.Content = new MemoryStream();
						await response.Content.CopyToAsync(result.Content);
						result.Content.Position = 0;
						result.FileName = response.Content.Headers.ContentDisposition.FileName;
					}

					return result;
				}
			}
		}

		internal async Task<MessageWithStatusCode> GetRequest(string url, string token = null)
		{
			using (var httpClient = PyrusClient.Settings.NewHttpClient())
			{
				SetHeaders(httpClient, token, UserAgent);
				using (var response = await httpClient.GetAsync(url))
				{
					var message = await response.Content.ReadAsStringAsync();
					return new MessageWithStatusCode { Message = message, StatusCode = response.StatusCode };
				}
			}
		}

		private void SetHeaders(HttpClient client, string token, string userAgent)
		{
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
			client.DefaultRequestHeaders.Add("ContentType", "application/json; charset=UTF-8");
			client.DefaultRequestHeaders.Add("User-Agent", userAgent);
		}

		public async Task<TResponse> RunQuery<TResponse>(Func<Task<MessageWithStatusCode>> action) where TResponse : ResponseBase
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
					{
						var resp = new DownloadResponse
						{
							Content = res.Content,
							FileName = res.FileName
						};

						if (res.StatusCode == HttpStatusCode.Forbidden || res.StatusCode == HttpStatusCode.NotFound)
							resp.ErrorCode = ErrorCodeType.AccessDeniedFile;
						else if (res.StatusCode != HttpStatusCode.OK)
							resp.ErrorCode = ErrorCodeType.ServerError;
						else if (res.StatusCode != HttpStatusCode.Unauthorized)
							resp.ErrorCode = ErrorCodeType.AuthorizationError;

						return resp as TResponse;
					}
						
					result = JsonConvert.DeserializeObject<TResponse>(res.Message, new FormFieldJsonConverter());
					if (result == null)
						continue;

					if (result.Error != null)
					{
						if (res.StatusCode != HttpStatusCode.Unauthorized || i == PyrusClient.Settings.RetryCount - 1)
							continue;

						var isValidParameters = await GetTokenAsync(PyrusClient.Login, PyrusClient.SecretKey);
						if (!isValidParameters)
						{
							return result;
						}
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

		private async Task<bool> GetTokenAsync(string login, string secretKey)
		{
			try
			{
				var url = PyrusClient.Settings.Origin + PyrusClient.AuthEndpoint + $"/?login={login}&security_key={secretKey}";
				
				var response = await GetRequest(url);
				var result = JsonConvert.DeserializeObject<AuthResponse>(response.Message);
				if (result.AccessToken == null)
					return false;

				PyrusClient.Token = result.AccessToken;
				return true;
			}
			catch (Exception e)
			{
				throw new PyrusApiClientException(e.Message, e);
			}
		}
	}
	internal class MessageWithStatusCode
	{
		internal string Message;
		internal HttpStatusCode StatusCode;
		internal Stream Content;
		internal string FileName;
	}
}
