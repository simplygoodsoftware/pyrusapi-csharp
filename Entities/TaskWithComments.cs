using System.Collections.Generic;
using Newtonsoft.Json;
using Pyrus.ApiClient.Entities;

namespace PyrusApiClient
{
	public class TaskWithComments : Task
	{
		[JsonProperty("comments")]
		public List<TaskComment> Comments { get; set; } = new List<TaskComment>();

		[JsonProperty("steps")]
		public List<Step> Steps { get; set; }
	}
}
