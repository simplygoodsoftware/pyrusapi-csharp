﻿using Pyrus.ApiClient.Enums;

namespace Pyrus.ApiClient.Requests.Builders
{
	public class CreateMemberRequestBuilder
	{
		private readonly CreateMemberRequest _request;

		public CreateMemberRequestBuilder(string email)
		{
			_request = new CreateMemberRequest
			{
				Email = email
			};
		}

		public CreateMemberRequestBuilder For(string firstName, string lastName)
		{
			_request.FirstName = firstName;
			_request.LastName = lastName;
			return this;
		}

		public CreateMemberRequestBuilder WorkingAt(int departmentId)
		{
			_request.DepartmentId = departmentId;
			return this;
		}

		public CreateMemberRequestBuilder As(string position)
		{
			_request.Position = position;
			return this;
		}

		public CreateMemberRequestBuilder WorkPhone(string phone)
		{
			_request.Phone = phone;
			return this;
		}

		public CreateMemberRequestBuilder LoginPhone(string phone)
		{
			_request.LoginPhone = phone;
			return this;
		}

		public CreateMemberRequestBuilder Skype(string skype)
		{
			_request.Skype = skype;
			return this;
		}

		public CreateMemberRequestBuilder WithRights(PersonRights rights)
		{
			_request.Rights = rights;
			return this;
		}

		public static implicit operator CreateMemberRequest(CreateMemberRequestBuilder cmrb)
		{
			return cmrb._request;
		}
	}
}
