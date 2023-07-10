using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyrus.ApiClient.Requests.Builders
{
	public class GetRoleRequestBuilder
	{
		public int RoleId { get; }

		public GetRoleRequestBuilder(int roleId)
		{
			RoleId = roleId;
		}
	}
}
