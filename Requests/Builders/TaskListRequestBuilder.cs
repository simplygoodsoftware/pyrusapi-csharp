namespace Pyrus.ApiClient.Requests.Builders
{
	public class TaskListRequestBuilder
	{
		internal int ListId { get; set; }

		internal int MaxItemCount { get; set; }

		internal bool IncludeArchived { get; set; }

		internal TaskListRequestBuilder(int listId, int maxItemCount, bool includeArchived)
		{
			ListId = listId;
			MaxItemCount = maxItemCount;
			IncludeArchived = includeArchived;
		}
	}
}