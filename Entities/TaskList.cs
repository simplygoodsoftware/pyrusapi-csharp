using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class TaskList
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("children")]
		public List<TaskList> Children { get; set; } = new List<TaskList>();
	}
}