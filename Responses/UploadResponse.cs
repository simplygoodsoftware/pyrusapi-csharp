using Newtonsoft.Json;
using PyrusApiClient;

namespace Pyrus.ApiClient.Responses
{
	public class UploadResponse : ResponseBase
	{
		[JsonProperty("guid")]
		public string Guid { get; set; }

		[JsonProperty("md5_hash")]
		public string MD5 { get; set; }
	}
}
