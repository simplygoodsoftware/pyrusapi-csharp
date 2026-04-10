using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class MeetingJoinParameters
	{
		[JsonProperty("url")]
		public string Url { get; set; }

		[JsonProperty("external_id")]
		public string ExternalId { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
