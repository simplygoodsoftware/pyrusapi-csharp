using Newtonsoft.Json;
using PyrusApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyrus.ApiClient.Responses
{
	public class BotResponse : ResponseBase
	{

		[JsonProperty("id")]
		public int? Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("is_enabled")]
		public bool? IsEnabled { get; set; }

		[JsonProperty("hook_url")]
		public string HookUrl { get; set; }

		[JsonProperty("description")]
		public string BotDescription { get; set; }

		[JsonProperty("settings")]
		public string BotSettings { get; set; }

		[JsonProperty("version")]
		public string BotVersion { get; set; }

		[JsonProperty("client_id")]
		public string ClientId { get; set; }

		[JsonProperty("event_type")]
		public int EventType { get; set; }

		[JsonProperty("login")]
		public string Login { get; set; }

		[JsonProperty("secret_key")]
		public string SecretKey { get; set; }

		public Bot Bot =>
			new Bot
			{
				Id = Id,
				Name = Name,
				IsEnabled = IsEnabled,
				HookUrl = HookUrl,
				BotDescription = BotDescription,
				BotSettings = BotSettings,
				BotVersion = BotVersion,
				ClientId = ClientId,
				EventType = EventType,
				Login = Login,
				SecretKey = SecretKey,
			};

	}
}
