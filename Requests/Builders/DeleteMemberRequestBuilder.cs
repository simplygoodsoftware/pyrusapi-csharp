using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyrus.ApiClient.Requests.Builders
{
    public class DeleteMemberRequestBuilder
    {
		public int MemberId { get; }

		public DeleteMemberRequestBuilder(int memberId)
		{
			MemberId = memberId;
		}

	}
}
