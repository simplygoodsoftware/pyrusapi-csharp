using Newtonsoft.Json;

namespace Pyrus.ApiClient.Requests
{
    public sealed class SessionLifespan
	{
		[JsonProperty("life_span_hours")]
		public int? LifespanHours { get; set; }

		[JsonProperty("disable")]
		public bool Drop { get; set; }

		[JsonProperty("drop")]
		public bool? Disable { get; set; }
	}
}
