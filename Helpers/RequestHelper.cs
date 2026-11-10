using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

		internal static Task<MessageWithStatusCode> PostRequest(PyrusClient client, string url, object request, string token = null,
			IReadOnlyDictionary<string, string> headers = null, CancellationToken cancellationToken = default)
			=> SendRequest(client, HttpMethod.Post, url, SerializeRequest(request), token, cancellationToken, headers);

		internal static Task<MessageWithStatusCode> PutRequest(PyrusClient client, string url, object request, string token = null)
			=> SendRequest(client, HttpMethod.Put, url, SerializeRequest(request), token);

		internal static async Task<MessageWithStatusCode> DeleteRequest(PyrusClient client, string url, string token = null)
		{
			using (var httpClient = client.ClientSettings.NewHttpClient(RequestTimeout))
			{
				SetHeaders(httpClient, token, UserAgent);
				using (var response = await httpClient.DeleteAsync(url))
				{
					var message = await response.Content.ReadAsStringAsync();
					return CreateMessageWithStatusCode(response, message);
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
					return CreateMessageWithStatusCode(response, message);
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

					return await SendRequest(client, HttpMethod.Get, url, null, token).ConfigureAwait(false);
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

		internal static string SerializeRequest(object request) => JsonConvert.SerializeObject(request, JsonSerializerSettings);

		internal static string SerializeChatRequest(SendChatMessageRequest request, string commandToken)
		{
			var payload = JObject.FromObject(request, JsonSerializer.Create(JsonSerializerSettings));
			payload["token"] = commandToken;
			return SerializeRequest(payload);
		}

		internal static async Task<MessageWithStatusCode> SendRequest(PyrusClient client, HttpMethod method, string url,
			string payload, string token, CancellationToken cancellationToken = default,
			IReadOnlyDictionary<string, string> headers = null)
		{
			using (var httpClient = client.ClientSettings.NewHttpClient(RequestTimeout))
			using (var request = new HttpRequestMessage(method, url))
			{
				SetHeaders(httpClient, token, UserAgent);
				AddHeaders(request, headers);
				if (payload != null)
					request.Content = new StringContent(payload, Encoding.UTF8, "application/json");
				using (var response = await httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false))
				{
					var message = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
					cancellationToken.ThrowIfCancellationRequested();
					return CreateMessageWithStatusCode(response, message);
				}
			}
		}

		internal static async Task<MessageWithStatusCode> PostFileRequest(PyrusClient client, string url, NoDisposeStreamWrapperFactory streamFactory, string fileName, string token, CancellationToken cancellationToken)
		{
			using (var httpClient = client.ClientSettings.NewHttpClient(FileRequestTimeout))
			{
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
				httpClient.DefaultRequestHeaders.Add("ContentType", "multipart/form-data");
				httpClient.DefaultRequestHeaders.Add("User-Agent", UserAgent);

				var streamContent = new StreamContent(streamFactory.Create());

				using var multipart = new MultipartFormDataContent { { streamContent, "file", fileName } };
				using (var response = await httpClient.PostAsync(url, multipart, cancellationToken))
				{
					var message = await response.Content.ReadAsStringAsync();
					cancellationToken.ThrowIfCancellationRequested();
					return CreateMessageWithStatusCode(response, message);
				}
			}
		}

		internal static async Task<MessageWithStatusCode> GetFileRequest(PyrusClient client, string url, string token,
			CancellationToken cancellationToken = default, bool readErrorBody = false)
		{
			using (var httpClient = client.ClientSettings.NewHttpClient(FileRequestTimeout))
			{
				if (!string.IsNullOrEmpty(token))
					httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
				httpClient.DefaultRequestHeaders.Add("User-Agent", UserAgent);
				using (var response = await httpClient.GetAsync(url, cancellationToken).ConfigureAwait(false))
				{
					var result = CreateMessageWithStatusCode(response, null);
					if (response.StatusCode != HttpStatusCode.OK)
					{
						if (readErrorBody && (int)response.StatusCode >= 400 && response.Content != null)
							result.Message = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
						cancellationToken.ThrowIfCancellationRequested();
						return result;
					}
					var buffer = new MemoryStream();
					try
					{
						using (var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
							await stream.CopyToAsync(buffer, 81920, cancellationToken).ConfigureAwait(false);
						buffer.Position = 0;
						result.Content = buffer;
						var disposition = response.Content.Headers.ContentDisposition;
						result.FileName = (!string.IsNullOrWhiteSpace(disposition?.FileNameStar) ? disposition.FileNameStar : disposition?.FileName)?.Trim('"');
						return result;
					}
					catch
					{
						buffer.Dispose();
						throw;
					}
				}
			}
		}

		private static MessageWithStatusCode CreateMessageWithStatusCode(HttpResponseMessage response, string message)
		{
			return new MessageWithStatusCode
			{
				Message = message,
				StatusCode = response.StatusCode,
				ContentType = response.Content?.Headers?.ContentType?.MediaType,
				ResponseDescription = response.ToString()
			};
		}

		private static void SetHeaders(HttpClient client, string token, string userAgent)
		{
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
			client.DefaultRequestHeaders.Add("ContentType", "application/json; charset=UTF-8");
			client.DefaultRequestHeaders.Add("User-Agent", userAgent);
		}

		private static void AddHeaders(HttpRequestMessage request, IReadOnlyDictionary<string, string> headers)
		{
			if (headers == null)
				return;

			foreach (var header in headers)
			{
				if (!string.IsNullOrEmpty(header.Key) && !string.IsNullOrEmpty(header.Value))
					request.Headers.TryAddWithoutValidation(header.Key, header.Value);
			}
		}
	}

	internal class MessageWithStatusCode
	{
		internal string Message;

		internal HttpStatusCode StatusCode;

		internal Stream Content;

		internal string FileName;

		internal string ContentType;

		internal string ResponseDescription;

		internal bool ToCsv => ContentType == "text/csv";
	}
}
