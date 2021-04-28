using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public static implicit operator UpdateMemberRequest(UpdateMemberRequestBuilder cmrb)
		{
			return cmrb._request;
		}
	}
}
