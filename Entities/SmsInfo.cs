using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class SmsInfo
	{
		[JsonProperty("error_code")]
		public SendSmsError ErrorCode { get; set; }

		[JsonProperty("status")]
		public SendSmsStatus Status { get; set; }

		[JsonProperty("error_message")]
		public string ErrorMessage { get; set; }
	}
}
