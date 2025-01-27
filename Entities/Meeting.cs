using System;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	public class Meeting
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("type")]
		public MeetingType Type { get; set; }

		[JsonProperty("start_time")]
		[JsonConverter(typeof(DateTimeJsonConverter), Constants.DateTimeFormat)]
		public DateTime? StartTime { get; set; }

		[JsonProperty("duration")]
		public int? Duration { get; set; }

		[JsonProperty("join_parameters")]
		public MeetingJoinParameters JoinParameters { get; set; }

		[JsonProperty("creator_id")]
		public int CreatorId { get; set; }

		[JsonProperty("task_id")]
		public int TaskId { get; set; }

		[JsonProperty("shared_calendar_event_id")]
		public string SharedCalendarEventId { get; set; }

		[JsonProperty("shared_to_email")]
		public bool SharedToEmail { get; set; }

		[JsonProperty("deleted")]
		public bool Deleted { get; set; }
	}
}
