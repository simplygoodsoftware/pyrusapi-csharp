using Pyrus.ApiClient.Enums;
using PyrusApiClient;

namespace Pyrus.ApiClient.Requests.Builders
{
	public class UpdateMemberRequestBuilder
	{
		public int MemberId { get; }
		private readonly UpdateMemberRequest _request;

		public UpdateMemberRequestBuilder(int memberId)
		{
			MemberId = memberId;
			_request = new UpdateMemberRequest();
		}

		public UpdateMemberRequestBuilder Rename(string firstName, string lastName)
		{
			_request.FirstName = firstName;
			_request.LastName = lastName;
			return this;
		}	
		
		public UpdateMemberRequestBuilder SetEmail(string email)
		{
			_request.Email = email;
			return this;
		}
		
		public UpdateMemberRequestBuilder WorkingAt(int departmentId)
		{
			_request.DepartmentId = departmentId;
			return this;
		}
		
		public UpdateMemberRequestBuilder As(string position)
		{
			_request.Position = position;
			return this;
		}
		
		public UpdateMemberRequestBuilder WorkPhone(string phone)
		{
			_request.Phone = phone;
			return this;
		}
		
		public UpdateMemberRequestBuilder LoginPhone(string phone)
		{
			_request.LoginPhone = phone;
			return this;
		}
		
		public UpdateMemberRequestBuilder Skype(string skype)
		{
			_request.Skype = skype;
			return this;
		}

		public UpdateMemberRequestBuilder Ban()
		{
			_request.Banned = true;
			return this;
		}

		public UpdateMemberRequestBuilder UnBan()
		{
			_request.Banned = false;
			return this;
		}

		public UpdateMemberRequestBuilder WithRights(PersonRights rights)
		{
			_request.Rights = rights;
			return this;
		}

		public UpdateMemberRequestBuilder WithMobileSessionLifespan(int hours)
		{
			_request.MobileSessionSettings = _request.MobileSessionSettings ?? new SessionLifespanUpdate();
			_request.MobileSessionSettings.LifespanHours = hours;
			return this;
		}

		public UpdateMemberRequestBuilder DropMobileSessionLifespan()
		{
			_request.MobileSessionSettings = _request.MobileSessionSettings ?? new SessionLifespanUpdate();
			_request.MobileSessionSettings.Drop = true;
			return this;
		}

		public UpdateMemberRequestBuilder DisableMobileSessionLifespan()
		{
			_request.MobileSessionSettings = _request.MobileSessionSettings ?? new SessionLifespanUpdate();
			_request.MobileSessionSettings.Disable = true;
			return this;
		}

		public UpdateMemberRequestBuilder EnableMobileSessionLifespan()
		{
			_request.MobileSessionSettings = _request.MobileSessionSettings ?? new SessionLifespanUpdate();
			_request.MobileSessionSettings.Disable = false;
			return this;
		}

		public UpdateMemberRequestBuilder WithWebSessionLifespan(int hours)
		{
			_request.WebSessionSettings = _request.WebSessionSettings ?? new SessionLifespanUpdate();
			_request.WebSessionSettings.LifespanHours = hours;
			return this;
		}

		public UpdateMemberRequestBuilder DropWebSessionLifespan()
		{
			_request.WebSessionSettings = _request.WebSessionSettings ?? new SessionLifespanUpdate();
			_request.WebSessionSettings.Drop = true;
			return this;
		}

		public UpdateMemberRequestBuilder DisableWebSessionLifespan()
		{
			_request.WebSessionSettings = _request.WebSessionSettings ?? new SessionLifespanUpdate();
			_request.WebSessionSettings.Disable = true;
			return this;
		}

		public UpdateMemberRequestBuilder EnableWebSessionLifespan()
		{
			_request.WebSessionSettings = _request.WebSessionSettings ?? new SessionLifespanUpdate();
			_request.WebSessionSettings.Disable = false;
			return this;
		}

		public UpdateMemberRequestBuilder WithMobileSessionInactivePeriod(int hours)
		{
			_request.MobileSessionInactiveSettings = _request.MobileSessionInactiveSettings ?? new SessionLifespanUpdate();
			_request.MobileSessionInactiveSettings.LifespanHours = hours;
			return this;
		}

		public UpdateMemberRequestBuilder DropMobileSessionInactivePeriod()
		{
			_request.MobileSessionInactiveSettings = _request.MobileSessionInactiveSettings ?? new SessionLifespanUpdate();
			_request.MobileSessionInactiveSettings.Drop = true;
			return this;
		}

		public UpdateMemberRequestBuilder DisableMobileSessionInactivePeriod()
		{
			_request.MobileSessionInactiveSettings = _request.MobileSessionInactiveSettings ?? new SessionLifespanUpdate();
			_request.MobileSessionInactiveSettings.Disable = true;
			return this;
		}

		public UpdateMemberRequestBuilder EnableMobileSessionInactivePeriod()
		{
			_request.MobileSessionInactiveSettings = _request.MobileSessionInactiveSettings ?? new SessionLifespanUpdate();
			_request.MobileSessionInactiveSettings.Disable = false;
			return this;
		}

		public UpdateMemberRequestBuilder WithWebSessionInactivePeriod(int hours)
		{
			_request.WebSessionInactiveSettings = _request.WebSessionInactiveSettings ?? new SessionLifespanUpdate();
			_request.WebSessionInactiveSettings.LifespanHours = hours;
			return this;
		}

		public UpdateMemberRequestBuilder DropWebSessionInactivePeriod()
		{
			_request.WebSessionInactiveSettings = _request.WebSessionInactiveSettings ?? new SessionLifespanUpdate();
			_request.WebSessionInactiveSettings.Drop = true;
			return this;
		}

		public UpdateMemberRequestBuilder DisableWebSessionInactivePeriod()
		{
			_request.WebSessionInactiveSettings = _request.WebSessionInactiveSettings ?? new SessionLifespanUpdate();
			_request.WebSessionInactiveSettings.Disable = true;
			return this;
		}

		public UpdateMemberRequestBuilder EnableWebSessionInactivePeriod()
		{
			_request.WebSessionInactiveSettings = _request.WebSessionInactiveSettings ?? new SessionLifespanUpdate();
			_request.WebSessionInactiveSettings.Disable = false;
			return this;
		}

		public static implicit operator UpdateMemberRequest(UpdateMemberRequestBuilder cmrb)
		{
			return cmrb._request;
		}
	}
}
