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

		[JsonProperty("note_id")]
		public long CommentId { get; set; }

		[JsonProperty("original_comment_id")]
		public long OriginalCommentId { get; set; }
	}
}
