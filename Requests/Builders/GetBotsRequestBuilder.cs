namespace Pyrus.ApiClient.Requests.Builders
{
	public class GetBotsRequestBuilder
	{
		public bool IncludeFiredBots { get; private set; }


		public GetBotsRequestBuilder()
		{
		}

		public GetBotsRequestBuilder IncludeFired()
		{
			IncludeFiredBots = true;
			return this;
		}
	}
}
