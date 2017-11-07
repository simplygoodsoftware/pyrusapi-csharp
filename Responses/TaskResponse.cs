using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class TaskResponse : ResponseBase
	{
		[JsonProperty("task")]
		public Task Task { get; set; }
	}
}
