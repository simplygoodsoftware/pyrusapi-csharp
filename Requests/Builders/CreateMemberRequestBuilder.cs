using Pyrus.ApiClient.Enums;
using PyrusApiClient;
using System;


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

		[Obsolete]
		public CreateMemberRequestBuilder Skype(string skype)
		{
			_request.Skype = skype;
			return this;
		}

		public CreateMemberRequestBuilder Messenger(string nickname, MessengerType messengerType)
		{
			_request.Messenger = new Messenger()
			{
				Nickname = nickname,
				Type = messengerType
			};
			return this;
		}

		public CreateMemberRequestBuilder WorkPhone(string phone)
		{
			_request.Phone = phone;
			return this;
		}

		public CreateMemberRequestBuilder MobilePhone(string phone)
		{
			_request.MobilePhone = phone;
			return this;
		}


		public CreateMemberRequestBuilder LoginPhone(string phone)
		{
			_request.LoginPhone = phone;
			return this;
		}

		public CreateMemberRequestBuilder Location(string location)
		{
			_request.Location = location;
			return this;
		}

		public CreateMemberRequestBuilder Personality(string personality)
		{
			_request.Personality = personality;
			return this;
		}

		public CreateMemberRequestBuilder PersonnelNumber(string personnelNumber)
		{
			_request.PersonnelNumber = personnelNumber;
			return this;
		}

		public CreateMemberRequestBuilder Status(string status)
		{
			_request.Status = status;
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
