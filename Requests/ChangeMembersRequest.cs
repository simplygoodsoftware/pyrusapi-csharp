using PyrusApiClient;
using System.Collections.Generic;

namespace Pyrus.ApiClient.Requests
{
	public class ChangeMembersRequest
	{
		public List<Person> AddMembers { get; set; }
		public List<Person> ChangeMembers { get; set; }
		public List<Person> BanMembers { get; set; }
	}
}
