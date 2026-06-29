using Pyrus.ApiClient.Enums;
using PyrusApiClient;

namespace Pyrus.ApiClient.Requests.Builders
{
	public class UpdateMeetingMyStatusBuilder
	{
		private readonly UpdateMeetingMyStatusRequest _request;

		public int MeetingId { get; }

		public UpdateMeetingMyStatusBuilder(int meetingId, MeetingMemberStatus status)
		{
			MeetingId = meetingId;
			_request = new UpdateMeetingMyStatusRequest { Status = status };
		}

		public static implicit operator UpdateMeetingMyStatusRequest(UpdateMeetingMyStatusBuilder builder) => builder._request;
	}
}
