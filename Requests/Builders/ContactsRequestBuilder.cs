namespace Pyrus.ApiClient.Requests.Builders
{
	public class ContactsRequestBuilder
	{
		private readonly ContactsRequest _request;

		public ContactsRequestBuilder IncludeInactive()
		{
			_request.IncludeInactive = true;
			return this;
		}
		public ContactsRequestBuilder()
		{
			_request = new ContactsRequest
			{
				IncludeInactive = false
			};
		}
		public static implicit operator ContactsRequest(ContactsRequestBuilder crb) => crb._request;

	}
}
