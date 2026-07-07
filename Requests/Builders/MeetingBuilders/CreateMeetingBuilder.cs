using System;
using PyrusApiClient;

namespace Pyrus.ApiClient.Requests.Builders
{
	public class CreateMeetingBuilder
	{
		private readonly CreateMeetingRequest _request;

		public CreateMeetingBuilder(MeetingType type, DateTime startTime, int durationMinutes, string title)
		{
			_request = new CreateMeetingRequest
			{
				Type = type,
				StartTime = startTime,
				DurationMinutes = durationMinutes,
				Title = title,
			};
		}

		public CreateMeetingBuilder SetNote(string note)
		{
			_request.Note = note;
			return this;
		}

		public CreateMeetingBuilder SetMembers(params int[] memberIds)
		{
			_request.MemberIds = memberIds;
			return this;
		}

		public CreateMeetingBuilder SetMeetingRooms(params long[] meetingRoomIds)
		{
			_request.MeetingRoomIds = meetingRoomIds;
			return this;
		}

		public CreateMeetingBuilder SetTasks(params int[] taskIds)
		{
			_request.TaskIds = taskIds;
			return this;
		}

		public CreateMeetingBuilder SharedToExternalPerson(bool value = true)
		{
			_request.ShouldBeSharedToExternalPerson = value;
			return this;
		}

		public static implicit operator CreateMeetingRequest(CreateMeetingBuilder builder) => builder._request;
	}
}
