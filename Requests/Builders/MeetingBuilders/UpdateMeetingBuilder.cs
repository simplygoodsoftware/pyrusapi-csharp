using System;
using PyrusApiClient;

namespace Pyrus.ApiClient.Requests.Builders
{
	public class UpdateMeetingBuilder
	{
		private readonly UpdateMeetingRequest _request;

		public int MeetingId { get; }

		public UpdateMeetingBuilder(int meetingId, MeetingType type, DateTime startTime, int durationMinutes, string title)
		{
			MeetingId = meetingId;
			_request = new UpdateMeetingRequest
			{
				Type = type,
				StartTime = startTime,
				DurationMinutes = durationMinutes,
				Title = title,
			};
		}

		public UpdateMeetingBuilder SetNote(string note)
		{
			_request.Note = note;
			return this;
		}

		public UpdateMeetingBuilder SetMembers(params int[] memberIds)
		{
			_request.MemberIds = memberIds;
			return this;
		}

		public UpdateMeetingBuilder SetMeetingRooms(params long[] meetingRoomIds)
		{
			_request.MeetingRoomIds = meetingRoomIds;
			return this;
		}

		public UpdateMeetingBuilder SharedToExternalPerson(bool value = true)
		{
			_request.ShouldBeSharedToExternalPerson = value;
			return this;
		}

		public static implicit operator UpdateMeetingRequest(UpdateMeetingBuilder builder) => builder._request;
	}
}
