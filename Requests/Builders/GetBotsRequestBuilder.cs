namespace Pyrus.ApiClient.Requests.Builders
{
	public class GetBotsRequestBuilder
	{
		public bool IncludeDeletedBots { get; private set; }


		public GetBotsRequestBuilder()
		{
		}

		public GetBotsRequestBuilder IncludeDeleted()
		{
			IncludeDeletedBots = true;
			return this;
		}
	}
}
