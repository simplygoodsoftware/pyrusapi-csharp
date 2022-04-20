using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pyrus.ApiClient.Helpers;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	internal static class RequestHelper
	{
		private static readonly TimeSpan RequestTimeout = TimeSpan.FromMinutes(2);
		private static readonly TimeSpan FileRequestTimeout = TimeSpan.FromMinutes(20);
		private static readonly TimeSpan DefaultRetryTimeout = TimeSpan.FromMilliseconds(200);

		private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
		{
			NullValueHandling = NullValueHandling.Ignore,
			DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
			Converters = new List<JsonConverter> { new FormRegisterRequestJsonConverter() },
			ContractResolver = ShouldSerializeListContractResolver.Instance
		};

		public static string CurrentVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

		private static string UserAgent =>
			$"PyrusApiClient/{CurrentVersion} ({Environment.OSVersion}; {(Environment.Is64BitOperatingSystem ? "x64" : "x32")})";

		internal static async Task<MessageWithStatusCode> PostRequest(PyrusClient client, string url, object request, string token = null)
		{
			using (var httpClient = client.ClientSettings.NewHttpClient(RequestTimeout))
			{
				SetHeaders(httpClient, token, UserAgent);
				using (var response = await httpClient.PostAsync(url,
					new StringContent(
						JsonConvert.SerializeObject(request,
							JsonSerializerSettings
							),
						Encoding.UTF8, "application/json")))
				{
					var message = await response.Content.ReadAsStringAsync();
					return new MessageWithStatusCode { Message = message, StatusCode = response.StatusCode, ResponseMessage = response };
				}
			}
		}

		internal static async Task<MessageWithStatusCode> PutRequest(PyrusClient client, string url, object request, string token = null)
		{
			using (var httpClient = client.ClientSettings.NewHttpClient(RequestTimeout))
			{
				SetHeaders(httpClient, token, UserAgent);
				using (var response = await httpClient.PutAsync(url,
					new StringContent(
						JsonConvert.SerializeObject(request,
							JsonSerializerSettings),
						Encoding.UTF8, "application/json")))
				{
					var message = await response.Content.ReadAsStringAsync();
					return new MessageWithStatusCode { Message = message, StatusCode = response.StatusCode, ResponseMessage = response };
				}
			}
		}

		internal static async Task<MessageWithStatusCode> DeleteRequest(PyrusClient client, string url, string token = null)
		{
			using (var httpClient = client.ClientSettings.NewHttpClient(RequestTimeout))
			{
				SetHeaders(httpClient, token, UserAgent);
				using (var response = await httpClient.DeleteAsync(url))
				{
					var message = await response.Content.ReadAsStringAsync();
					return new MessageWithStatusCode { Message = message, StatusCode = response.StatusCode, ResponseMessage = response };
				}
			}
		}

		internal static async Task<MessageWithStatusCode> DeleteRequest(PyrusClient client, string url, object request, string token = null)
		{
			using (var httpClient = client.ClientSettings.NewHttpClient(RequestTimeout))
			using (var httpRequest = new HttpRequestMessage())
			{
				SetHeaders(httpClient, token, UserAgent);

				httpRequest.Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
				httpRequest.Method = HttpMethod.Delete;
				httpRequest.RequestUri = new Uri(url);

				using (var response = await httpClient.SendAsync(httpRequest))
				{
					var message = await response.Content.ReadAsStringAsync();
					return new MessageWithStatusCode { Message = message, StatusCode = response.StatusCode, ResponseMessage = response };
				}
			}
		}

		internal static async Task<MessageWithStatusCode> PostFileRequest(PyrusClient client, string url, NoDisposeStreamWrapperFactory streamFactory, string fileName, string token)
		{
			using (var httpClient = client.ClientSettings.NewHttpClient(FileRequestTimeout))
			{
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
				httpClient.DefaultRequestHeaders.Add("ContentType", "multipart/form-data");
				httpClient.DefaultRequestHeaders.Add("User-Agent", UserAgent);

				var streamContent = new StreamContent(streamFactory.Create());

				var multipart = new MultipartFormDataContent { { streamContent, "file", $"{fileName}" } };
				using (var response = await httpClient.PostAsync(url, multipart))
				{
					var message = await response.Content.ReadAsStringAsync();
					return new MessageWithStatusCode { Message = message, StatusCode = response.StatusCode, ResponseMessage = response };
				}
			}
		}

		internal static async Task<MessageWithStatusCode> GetFileRequest(PyrusClient client, string url, string token)
		{
			using (var httpClient = client.ClientSettings.NewHttpClient(FileRequestTimeout))
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

						if (response.Content.Headers.ContentDisposition != null)
						{
							result.FileName = !string.IsNullOrWhiteSpace(response.Content.Headers.ContentDisposition.FileNameStar)
								? response.Content.Headers.ContentDisposition.FileNameStar
								: response.Content.Headers.ContentDisposition.FileName;
							result.FileName = result.FileName.TrimStart('"').TrimEnd('"');
						}
					}

					return result;
				}
			}
		}

		internal static async Task<MessageWithStatusCode> GetRequest(PyrusClient client, string url, string token = null)
		{
			for (var i = 0; i <= client.ClientSettings.RetryCount; i++)
			{
				try
				{
					if (i > 0)
						await System.Threading.Tasks.Task.Delay(DefaultRetryTimeout);

					using (var httpClient = client.ClientSettings.NewHttpClient(RequestTimeout))
					{
						SetHeaders(httpClient, token, UserAgent);
						using (var response = await httpClient.GetAsync(url))
						{
							var message = await response.Content.ReadAsStringAsync();
							return new MessageWithStatusCode
							{ Message = message, StatusCode = response.StatusCode, ResponseMessage = response };
						}
					}

				}
				catch (HttpRequestException)
				{
					if (i == client.ClientSettings.RetryCount)
						throw;
				}
				catch (WebException)
				{
					if (i == client.ClientSettings.RetryCount)
						throw;
				}
				catch (TaskCanceledException)
				{
					if (i == client.ClientSettings.RetryCount)
						throw;
				}
			}
			return null;
		}

		private static void SetHeaders(HttpClient client, string token, string userAgent)
		{
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
			client.DefaultRequestHeaders.Add("ContentType", "application/json; charset=UTF-8");
			client.DefaultRequestHeaders.Add("User-Agent", userAgent);
		}
	}
	internal class MessageWithStatusCode
	{
		internal string Message;
		internal HttpStatusCode StatusCode;
		internal Stream Content;
		internal string FileName;
		internal HttpResponseMessage ResponseMessage;
		internal bool ToCsv => ResponseMessage.Content.Headers.ContentType.MediaType == "text/csv";
	}
}
