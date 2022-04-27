using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class SessionLifespan
	{
		[JsonProperty("life_span_hours")]
		public int? LifespanHours { get; set; }

		[JsonProperty("disable")]
		public bool? Disable { get; set; }
	}

	public class SessionLifespanUpdate
	{
		[JsonProperty("life_span_hours")]
		public int? LifespanHours { get; set; }

		[JsonProperty("disable")]
		public bool? Disable { get; set; }

		[JsonProperty("disable")]
		public bool Drop { get; set; }
	}
}
