using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class BpmnTimer
	{
		[JsonProperty("mode")]
		public BpmnTimerMode Mode { get; set; }

		[JsonProperty("days")]
		public int? Days { get; set; }

		[JsonProperty("hours")]
		public int? Hours { get; set; }

		[JsonProperty("minutes")]
		public int? Minutes { get; set; }
	}
}
