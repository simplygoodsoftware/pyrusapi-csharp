using Newtonsoft.Json;
using Pyrus.ApiClient.Enums;

namespace PyrusApiClient
{
	public class ExternalComment
	{
		[JsonProperty(PropertyName = "channel")]
		public Channel Channel { get; set; }

		[JsonProperty(PropertyName = "to")]
		public string To { get; set; }
	}
}
