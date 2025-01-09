using System;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class CalendarTasksRequest
	{
		[JsonProperty(PropertyName = "start_date_utc")]
		public DateTime StartDateUtc { get; set; }
		
		[JsonProperty(PropertyName = "end_date_utc")]
		public DateTime EndDateUtc { get; set; }
		
		[JsonProperty(PropertyName = "item_count")]
		public int? ItemCount { get; set; }
		
		[JsonProperty(PropertyName = "all_accessed_tasks")]
		public bool AllAccessedTasks { get; set; }
		
		[JsonProperty(PropertyName = "filter_mask")]
		public int? FilterMask { get; set; }

		[JsonProperty(PropertyName = "include_meetings")]
		public bool IncludeMeetings { get; set; }
    }
}
