using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class Channel
	{
		[JsonProperty(PropertyName = "type")]
		public ChannelType Type { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

		[JsonProperty(PropertyName = "to")]
		public ChannelUser To { get; set; }

		[JsonProperty(PropertyName = "from")]
		public ChannelUser From { get; set; }
	}
}
