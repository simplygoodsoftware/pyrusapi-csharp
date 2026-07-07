using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class MeetingRoom
	{
		[JsonProperty("id")]
		public long Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
