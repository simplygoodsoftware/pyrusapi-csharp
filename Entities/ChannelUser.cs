using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class ChannelUser
	{
		[JsonProperty(PropertyName = "email")]
		public string Email { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }
	}
}
