namespace Pyrus.ApiClient.Requests.Builders
{
	public class GetMembersRequestBuilder
	{
		public bool IncludeFiredMembers { get; private set; }


		public GetMembersRequestBuilder()
		{
		}

		public GetMembersRequestBuilder IncludeFired()
		{
			IncludeFiredMembers = true;
			return this;
		}
	}
}
