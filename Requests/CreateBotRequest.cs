using Newtonsoft.Json;

namespace Pyrus.ApiClient.Requests
{
	public class CreateBotRequest
	{
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "hook_url")]
		public string HookUrl { get; set; }

		[JsonProperty(PropertyName = "external_id")]
		public string ExternalId { get; set; }
	}
}
