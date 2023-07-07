using System;

namespace Pyrus.ApiClient.Requests.Builders
{
	public class SetAvatarRequestBuilder
	{
		public int MemberId { get; }
		private readonly SetAvatarRequest _request;

		public SetAvatarRequestBuilder(int memberId)
		{
			MemberId = memberId;
			_request = new SetAvatarRequest();
		}

		public SetAvatarRequestBuilder SetGuid(Guid guid)
		{
			_request.Guid = guid;
			return this;
		}

		public static implicit operator SetAvatarRequest(SetAvatarRequestBuilder cmrb)
		{
			return cmrb._request;
		}
	}
}
