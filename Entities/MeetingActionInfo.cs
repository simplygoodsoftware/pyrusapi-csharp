using System;
using Newtonsoft.Json;
using Pyrus.ApiClient.Enums;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	public class MeetingActionInfo
	{
		[JsonProperty("action_type")]
		public MeetingActionType ActionType { get; set; }

		[JsonProperty("meeting_id")]
		public int? MeetingId { get; set; }

		[JsonProperty("type")]
		public MeetingType? Type { get; set; }

		[JsonProperty("start_time")]
		[JsonConverter(typeof(DateTimeJsonConverter), Constants.DateTimeFormat)]
		public DateTime? StartTime { get; set; }

		[JsonProperty("duration_minutes")]
		public int? DurationMinutes { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("note")]
		public string Note { get; set; }

		[JsonProperty("join_parameters")]
		public MeetingJoinParameters JoinParameters { get; set; }
	}
}
