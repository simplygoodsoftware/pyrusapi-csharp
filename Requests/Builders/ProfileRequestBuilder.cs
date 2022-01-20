namespace Pyrus.ApiClient.Requests.Builders
{
	public class ProfileRequestBuilder
	{
		private readonly ProfileRequest _request;

		public ProfileRequestBuilder WithInactive()
		{
			_request.WithInactive = true;
			return this;
		}
		public ProfileRequestBuilder()
		{
			_request = new ProfileRequest
			{
				WithInactive = false
			};
		}
		public static implicit operator ProfileRequest(ProfileRequestBuilder prb) => prb._request;

	}
}