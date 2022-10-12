using Newtonsoft.Json;
using Pyrus.ApiClient.Enums;
using PyrusApiClient;

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

		[JsonProperty("fired")]
		public bool Fired { get; set; }

		[JsonProperty("hook_url")]
		public string HookUrl { get; set; }

		[JsonProperty("description")]
		public string BotDescription { get; set; }

		[JsonProperty("bot_settings")]
		public string BotSettings { get; set; }

		[JsonProperty("version")]
		public string BotVersion { get; set; }

		[JsonProperty("login")]
		public string Login { get; set; }

		[JsonProperty("rights")]
		public PersonRights? Rights { get; set; }

		[JsonProperty("send_only_last_comment")]
		public bool? SendOnlyLastComment { get; set; }

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
				Login = Login,
				Rights = Rights,
				SendOnlyLastComment = SendOnlyLastComment,
			};

	}
}
