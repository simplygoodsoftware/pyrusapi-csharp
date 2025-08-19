namespace Pyrus.ApiClient.Requests.Builders
{
    public class InboxRequestBuilder
    {
        private readonly InboxRequest _request;

        public InboxRequestBuilder(int tasksCount, int groupTasksCount)
        {
            _request = new InboxRequest()
            {
                TasksCount = tasksCount,
                GroupTasksCount = groupTasksCount,
            };
        }

        public static implicit operator InboxRequest(InboxRequestBuilder builder)
        {
            return builder._request;
        }
    }
}
