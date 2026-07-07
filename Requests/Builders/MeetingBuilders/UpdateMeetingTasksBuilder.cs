using PyrusApiClient;

namespace Pyrus.ApiClient.Requests.Builders
{
	public class UpdateMeetingTasksBuilder
	{
		private readonly UpdateMeetingTasksRequest _request = new UpdateMeetingTasksRequest();

		public int MeetingId { get; }

		public UpdateMeetingTasksBuilder(int meetingId)
		{
			MeetingId = meetingId;
		}

		public UpdateMeetingTasksBuilder AddTasks(params int[] taskIds)
		{
			_request.Add = taskIds;
			return this;
		}

		public UpdateMeetingTasksBuilder RemoveTasks(params int[] taskIds)
		{
			_request.Remove = taskIds;
			return this;
		}

		public static implicit operator UpdateMeetingTasksRequest(UpdateMeetingTasksBuilder builder) => builder._request;
	}
}
