using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class TaskList : PlainTaskList
	{
		[JsonProperty("children")]
		public List<TaskList> Children { get; set; } = new List<TaskList>();
	}
}