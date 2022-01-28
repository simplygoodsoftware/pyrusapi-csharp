namespace Pyrus.ApiClient.Requests.Builders
{
	public class ProfileRequestBuilder
	{
		private readonly ProfileRequest _request;

		public ProfileRequestBuilder IncludeInactive()
		{
			_request.IncludeInactive = true;
			return this;
		}
		public ProfileRequestBuilder()
		{
			_request = new ProfileRequest
			{
				IncludeInactive = false
			};
		}
		public static implicit operator ProfileRequest(ProfileRequestBuilder prb) => prb._request;

	}
}