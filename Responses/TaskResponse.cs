using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class TaskResponse : ResponseBase
	{
		[JsonProperty("task")]
		public TaskWithComments Task { get; set; }
	}
}
