using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class UpdateMeetingTasksRequest
	{
		[JsonProperty("add", NullValueHandling = NullValueHandling.Ignore)]
		public int[] Add { get; set; }

		[JsonProperty("remove", NullValueHandling = NullValueHandling.Ignore)]
		public int[] Remove { get; set; }
	}
}
