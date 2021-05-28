using Newtonsoft.Json;

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

		[JsonProperty("hook_url")]
		public string HookUrl { get; set; }

		[JsonProperty("bot_description")]
		public string BotDescription { get; set; }

		[JsonProperty("bot_settings")]
		public string BotSettings { get; set; }

		[JsonProperty("bot_version")]
		public string BotVersion { get; set; }

		[JsonProperty("client_id")]
		public string ClientId { get; set; }

		[JsonProperty("event_type")]
		public int EventType { get; set; }

		[JsonProperty("login")]
		public string Login { get; set; }

		[JsonProperty("secret_key")]
		public string SecretKey { get; set; }

		public override string ToString()
		{
			return Id?.ToString() ?? Name;
		}
	}
}
