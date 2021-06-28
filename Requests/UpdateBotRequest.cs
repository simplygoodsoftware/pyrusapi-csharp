using Newtonsoft.Json;

namespace Pyrus.ApiClient.Requests
{
	public class UpdateBotRequest
	{
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "hook_url")]
		public string HookUrl { get; set; }

		[JsonProperty(PropertyName = "is_enabled")]
		public bool? IsEnabled { get; set; }

		[JsonProperty(PropertyName = "settings")]
		public string BotSettings { get; set; }

		[JsonProperty(PropertyName = "description")]
		public string BotDescription { get; set; }
	}
}
