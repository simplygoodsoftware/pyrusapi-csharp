using Newtonsoft.Json;
using System;

namespace Pyrus.ApiClient.Requests
{
	public class TaskListRequest
	{
		[JsonProperty("include_archived")]
		internal string IncludeArchived { get; set; }

		[JsonProperty("modified_before")]
		internal DateTime? ModifiedBefore { get; set; }

		[JsonProperty("modified_after")]
		internal DateTime? ModifiedAfter { get; set; }

		[JsonProperty("item_count")]
		internal int MaxItemCount { get; set; }
	}
}
