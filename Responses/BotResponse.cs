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

		[JsonProperty("avatar_id")]
		public int? AvatarId { get; set; }

		[JsonProperty("external_avatar_id")]
		public int? ExternalAvatarId { get; set; }

		[JsonProperty("version")]
		public string BotVersion { get; set; }

		[JsonProperty("login")]
		public string Login { get; set; }

		[JsonProperty("rights")]
		public PersonRights? Rights { get; set; }

		[JsonProperty("send_only_last_comment")]
		public bool? SendOnlyLastComment { get; set; }

		[JsonProperty("locale")]
		public string Locale { get; set; }

		[JsonProperty("time_zone_offset")]
		public int? TimeZoneOffset { get; set; }

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
				AvatarId = AvatarId,
				ExternalAvatarId = ExternalAvatarId,
				Login = Login,
				Rights = Rights,
				SendOnlyLastComment = SendOnlyLastComment,
				Locale = Locale,
				TimeZoneOffset = TimeZoneOffset
			};

	}
}
