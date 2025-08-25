using Newtonsoft.Json;
using System.Collections.Generic;

namespace PyrusApiClient
{
	public class InboxResponse : TaskListResponse
	{
        [JsonProperty("task_groups")]
        public List<TaskGroup> TaskGroups { get; set; }
    }
}
