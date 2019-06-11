using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class ExternalComment
	{
		[JsonProperty(PropertyName = "channel")]
		public Channel Channel { get; set; }

		[JsonProperty(PropertyName = "to")]
		public string To { get; set; }
	}
}
