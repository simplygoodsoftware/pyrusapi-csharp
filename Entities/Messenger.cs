using Newtonsoft.Json;
using Pyrus.ApiClient.Enums;

namespace PyrusApiClient
{
	public class Messenger
	{
		[JsonProperty("type")]
		public MessengerType? Type { get; set; }

		[JsonProperty("nickname")]
		public string Nickname { get; set; }


		public override string ToString() => Nickname;
	}
}
