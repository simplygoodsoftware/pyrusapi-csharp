using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class ExternalComment
	{
		[JsonProperty(PropertyName = "channel")]
		public Channel Channel { get; set; }

		[JsonProperty(PropertyName = "to")]
		public ExternalCommentUser To { get; set; }

		[JsonProperty(PropertyName = "from")]
		public ExternalCommentUser From { get; set; }
	}
}
