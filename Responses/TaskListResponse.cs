using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class TaskListResponse : ResponseBase
	{
		[JsonProperty("tasks")]
		public List<TaskHeader> Tasks { get; set; }

		[JsonProperty("has_more")]
		public bool HasMore { get; set; }
	}
}
