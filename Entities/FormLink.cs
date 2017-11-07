using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormLink
	{
		[JsonProperty("task_id")]
		public int? TaskId { get; set; }

		[JsonProperty("subject")]
		public string Subject { get; set; }
	}
}
