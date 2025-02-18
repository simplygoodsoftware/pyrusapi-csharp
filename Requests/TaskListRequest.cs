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

		[JsonProperty("created_before")]
		public DateTime? CreatedBefore { get; set; }

		[JsonProperty("created_after")]
		public DateTime? CreatedAfter { get; set; }

		[JsonProperty("closed_before")]
		public DateTime? ClosedBefore { get; set; }

		[JsonProperty("closed_after")]
		public DateTime? ClosedAfter { get; set; }

		[JsonProperty("item_count")]
		internal int MaxItemCount { get; set; }
	}
}
