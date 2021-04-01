using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyrus.ApiClient.Requests.Builders
{
   public  class CreateMemberRequestBuilder
    {
        private readonly CreateMemberRequest _request;

        public CreateMemberRequestBuilder(string email)
        {
            _request = new CreateMemberRequest
            {
                Email = email
            };
        }

		public CreateMemberRequestBuilder WithFirstName(string name)
		{
			_request.FirstName = name;
			return this;
		}

		public CreateMemberRequestBuilder WithLastName(string name)
		{
			_request.LastName = name;
			return this;
		}

		public CreateMemberRequestBuilder WithEmail(string email)
		{
			_request.Email = email;
			return this;
		}

		public CreateMemberRequestBuilder WithDepartmentId(int departmentId)
		{
			_request.DepartmentId = departmentId;
			return this;
		}

		public CreateMemberRequestBuilder WithPosition(string position)
		{
			_request.Position = position;
			return this;
		}

		public CreateMemberRequestBuilder WithPhone(string phone)
		{
			_request.Phone = phone;
			return this;
		}

		public CreateMemberRequestBuilder WithSkype(string skype)
		{
			_request.Skype = skype;
			return this;
		}

		public static implicit operator CreateMemberRequest(CreateMemberRequestBuilder cmrb)
        {
            return cmrb._request;
        }
    }
}
