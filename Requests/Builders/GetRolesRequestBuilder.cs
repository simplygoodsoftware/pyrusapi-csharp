namespace Pyrus.ApiClient.Requests.Builders
{
	public class GetRolesRequestBuilder
	{
		public bool IncludeFiredRoles { get; private set; }


		public GetRolesRequestBuilder()
		{
		}

		public GetRolesRequestBuilder IncludeFired()
		{
			IncludeFiredRoles = true;
			return this;
		}
	}
}
