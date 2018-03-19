using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class TaskWithComments : Task
	{
		[JsonProperty("comments")]
		public List<TaskComment> Comments { get; set; } = new List<TaskComment>();
	}
}
