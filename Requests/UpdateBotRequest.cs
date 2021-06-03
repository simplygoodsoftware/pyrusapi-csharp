using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		[JsonProperty(PropertyName = "update_secret_key")]
		public bool? UpdateSecretKey { get; set; }

		[JsonProperty(PropertyName = "parameters")]
		public string BotSettings { get; set; }

		[JsonProperty(PropertyName = "description")]
		public string BotDescription { get; set; }
	}
}
