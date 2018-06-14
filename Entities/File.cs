using System.IO;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class File
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("size")]
		public long Size { get; set; }

		[JsonProperty("md5")]
		public string MD5 { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }
	}
}
