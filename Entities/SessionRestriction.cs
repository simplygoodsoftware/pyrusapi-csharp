using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class SessionRestriction
	{
		[JsonProperty("max_count")]
		public int? MaxCount { get; set; }

		[JsonProperty("disable")]
		public bool Disable { get; set; }
	}

	public class SessionRestrictionUpdate
	{
		[JsonProperty("max_count")]
		public int? MaxCount { get; set; }

		[JsonProperty("disable")]
		public bool? Disable { get; set; }

		[JsonProperty("drop")]
		public bool Drop { get; set; }
	}
}
