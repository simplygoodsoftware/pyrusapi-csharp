using System;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	public class CreateMeetingRequest
	{
		[JsonProperty("type")]
		public MeetingType Type { get; set; }

		[JsonProperty("start_time")]
		[JsonConverter(typeof(DateTimeJsonConverter), Constants.DateTimeFormat)]
		public DateTime StartTime { get; set; }

		[JsonProperty("duration_minutes")]
		public int DurationMinutes { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
		public string Note { get; set; }

		[JsonProperty("member_ids", NullValueHandling = NullValueHandling.Ignore)]
		public int[] MemberIds { get; set; }

		[JsonProperty("meeting_room_ids", NullValueHandling = NullValueHandling.Ignore)]
		public long[] MeetingRoomIds { get; set; }

		[JsonProperty("task_ids", NullValueHandling = NullValueHandling.Ignore)]
		public int[] TaskIds { get; set; }

		[JsonProperty("should_be_shared_to_external_person", NullValueHandling = NullValueHandling.Ignore)]
		public bool? ShouldBeSharedToExternalPerson { get; set; }
	}
}
