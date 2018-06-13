using System.IO;
using PyrusApiClient;

namespace Pyrus.ApiClient.Responses
{
	public class DownloadResponse : ResponseBase
	{
		public Stream Content { get; set; }

		public string FileName { get; set; }
	}
}
