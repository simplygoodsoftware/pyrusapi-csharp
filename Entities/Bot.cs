﻿using Newtonsoft.Json;

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

		[JsonProperty("description")]
		public string BotDescription { get; set; }

		[JsonProperty("settings")]
		public string BotSettings { get; set; }

		[JsonProperty("version")]
		public string BotVersion { get; set; }

		[JsonProperty("login")]
		public string Login { get; set; }

		public override string ToString()
		{
			return Id?.ToString() ?? Name;
		}
	}
}
