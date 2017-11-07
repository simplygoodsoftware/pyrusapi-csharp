using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class ResponseBase
	{
		[JsonProperty("error")]
		public string Error { get; set; }

		[JsonProperty("error_code")]
		public ErrorCodeType? ErrorCode { get; set; }
	}
}
