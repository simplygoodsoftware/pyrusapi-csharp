using System.IO;

namespace Pyrus.ApiClient.Requests.Builders
{
	public class UploadRequestBuilder
	{
		internal Stream FileStream { get; set; }

		internal string FileName { get; set; }

		internal string FilePath { get; set; }

		internal UploadRequestBuilder(Stream stream, string name)
		{
			FileStream = stream;
			FileName = name;
		}

		internal UploadRequestBuilder(string path)
		{
			FilePath = path;
		}
	}
}