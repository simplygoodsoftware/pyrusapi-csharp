using Newtonsoft.Json;
using Pyrus.ApiClient.Enums;

namespace PyrusApiClient
{
	public class Bot
	{
		public Bot()
		{
		}

		public Bot(int id)
		{
			Id = id;
		}

		public Bot(string name)
		{
			Name = name;
		}

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

		[JsonProperty("external_id")]
		public string ExternalId { get; set; }

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

		public override string ToString() => Id?.ToString() ?? Name;
	}
}
