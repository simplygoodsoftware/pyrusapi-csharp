﻿using Newtonsoft.Json;
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

		[JsonProperty("login")]
		public string Login { get; set; }


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
			};

	}
}
