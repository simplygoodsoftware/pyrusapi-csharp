namespace Pyrus.ApiClient.Requests.Builders
{
	public class ContactsRequestBuilder
	{
		private readonly ContactsRequest _request;

		public ContactsRequestBuilder WithInactive()
		{
			_request.WithInactive = true;
			return this;
		}
		public ContactsRequestBuilder()
		{
			_request = new ContactsRequest
			{
				WithInactive = false
			};
		}
		public static implicit operator ContactsRequest(ContactsRequestBuilder crb) => crb._request;

	}
}
