using System;

namespace Pyrus.ApiClient.Requests.Builders
{
	public class TaskListRequestBuilder
	{
		private readonly TaskListRequest _taskListRequest;
		internal int ListId { get; set; }

		internal TaskListRequestBuilder(int listId, int maxItemCount, bool includeArchived)
		{
			_taskListRequest = new TaskListRequest();
			ListId = listId;
			_taskListRequest.MaxItemCount = maxItemCount;
			_taskListRequest.IncludeArchived = includeArchived ? "y": string.Empty;
		}

		public static implicit operator TaskListRequest(TaskListRequestBuilder tlrb) => tlrb._taskListRequest;

		internal TaskListRequestBuilder(TaskListRequest taskListRequest, int listId)
		{
			_taskListRequest = taskListRequest;
			taskListRequest.IncludeArchived = string.Empty;
			ListId = listId;
		}

		public TaskListRequestBuilder IncludeArchived()
		{
			_taskListRequest.IncludeArchived = "y";
			return this;
		}

		public TaskListRequestBuilder ModifiedBefore(DateTime dateTime)
		{
			_taskListRequest.ModifiedBefore = dateTime;
			return this;
		}

		public TaskListRequestBuilder ModifiedAfter(DateTime dateTime)
		{
			_taskListRequest.ModifiedAfter = dateTime;
			return this;
		}

		public TaskListRequestBuilder MaxItemCount(int maxItemCount)
		{
			if (maxItemCount <= 0)
				throw new ArgumentOutOfRangeException(nameof(maxItemCount));
			_taskListRequest.MaxItemCount = maxItemCount;
			return this;
		}

	}
}