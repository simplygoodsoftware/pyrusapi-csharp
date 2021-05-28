using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyrus.ApiClient.Requests
{
	public class CreateBotRequest
	{
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "hook_url")]
		public string HookUrl { get; set; }

		[JsonProperty(PropertyName = "version")]
		public int BotVersion { get; set; } = 4;

		[JsonProperty(PropertyName = "need_url_validation")]
		public bool? NeedUrlValidation { get; set; }
	}
}
