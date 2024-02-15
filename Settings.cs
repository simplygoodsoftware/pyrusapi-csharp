using System;
using System.Net;
using System.Net.Http;

namespace PyrusApiClient
{
	public class Settings
	{
		public const string PyrusOrigin = "https://api.pyrus.com/v4";
		public const string PyrusAuthOrigin = "https://accounts.pyrus.com/api/v4";
		public const string PyrusFilesOrigin = "https://files.pyrus.com";

		public Settings()
			: this(PyrusOrigin, PyrusFilesOrigin)
		{
		}

		public Settings(string origin, string filesOrigin)
		{
			Origin = origin;
			FilesOrigin = filesOrigin;
			AuthOrigin = PyrusAuthOrigin;
			
			RetryCount = 2;
		}

		private string _origin;

		public string Origin {
			get { return _origin; } 
			set
			{
				if (value.EndsWith("/"))
					value = value.TrimEnd('/');
				
				_origin = value;
			}
		}

		private string _filesOrigin;

		public string FilesOrigin
		{
			get => _filesOrigin;
			set
			{
				if (value.EndsWith("/"))
					value = value.TrimEnd('/');

				_filesOrigin = value;
			}
		}

		private string _authOrigin;

		public string AuthOrigin
		{
			get => _authOrigin;
			set
			{
				if (value.EndsWith("/"))
					value = value.TrimEnd('/');

				_authOrigin = value;
			}
		}

		public string ProxyIp { get; set; }

		public string ProxyPort { get; set; }

		public string ProxyUserName { get; set; }

		public string ProxyPassword { get; set; }

		public int RetryCount { get; set; }


		public virtual HttpClient NewHttpClient(TimeSpan timeout)
        {
            return new HttpClient(GetHttpHandler())
			{
				Timeout = timeout
			};
		}

		private HttpClientHandler GetHttpHandler()
		{
			if (String.IsNullOrWhiteSpace(ProxyIp))
			{
				return new HttpClientHandler
				{
					AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
				};
			}

			var proxyUri = $"{ProxyIp}{(String.IsNullOrWhiteSpace(ProxyPort) ? "" : ":" + ProxyPort)}";

			if (String.IsNullOrWhiteSpace(ProxyUserName))
			{
				var proxy = new WebProxy(proxyUri);
				return new HttpClientHandler
				{
					Proxy = proxy,
					PreAuthenticate = false,
					AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
				};
			}
			else
			{
				var proxyCreds = new NetworkCredential(ProxyUserName, ProxyPassword);
				var proxy = new WebProxy(proxyUri, false)
				{
					UseDefaultCredentials = false,
					Credentials = proxyCreds,
				};

				return new HttpClientHandler
				{
					Proxy = proxy,
					PreAuthenticate = true,
					UseDefaultCredentials = false,
					AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
				};
			}
		}
	}
}

