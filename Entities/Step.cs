using Newtonsoft.Json;

namespace Pyrus.ApiClient.Entities
{
	public class Step
	{
		[JsonProperty("step")]
		public int StepNumber { get; set; }

		[JsonProperty("elapsed_time")]
		public long ElapsedTime { get; set; }

		[JsonProperty("name")]
		public string StepName { get; set; }
	}
}
