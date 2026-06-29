using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;
using PyrusApiClient;

namespace Pyrus.ApiClient.Responses
{
	public class MeetingResponse : ResponseBase
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("type")]
		public MeetingType Type { get; set; }

		[JsonProperty("start_time")]
		[JsonConverter(typeof(DateTimeJsonConverter), Constants.DateTimeFormat)]
		public DateTime StartTime { get; set; }

		[JsonProperty("duration_minutes")]
		public int DurationMinutes { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("note")]
		public string Note { get; set; }

		[JsonProperty("creator")]
		public MeetingPersonInfo Creator { get; set; }

		[JsonProperty("task_ids")]
		public List<int> TaskIds { get; set; } = new List<int>();

		[JsonProperty("members")]
		public List<MeetingMember> Members { get; set; } = new List<MeetingMember>();

		[JsonProperty("meeting_rooms")]
		public List<MeetingRoom> MeetingRooms { get; set; } = new List<MeetingRoom>();

		[JsonProperty("join_parameters")]
		public MeetingJoinParameters JoinParameters { get; set; }

		[JsonProperty("shared_calendar_event_id")]
		public Guid SharedCalendarEventId { get; set; }

		[JsonProperty("should_be_shared_to_external_person")]
		public bool ShouldBeSharedToExternalPerson { get; set; }
	}
}
