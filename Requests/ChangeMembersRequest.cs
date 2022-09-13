﻿using PyrusApiClient;
using System.Collections.Generic;

namespace Pyrus.ApiClient.Requests
{
	public class ChangeMembersRequest
	{
		public List<Person> AddMembers { get; set; }
		public List<ChangeMemberRequest> ChangeMembers { get; set; }
		public List<Person> BanMembers { get; set; }
		public List<FirePersonRequest> FireMembers { get; set; }
	}
}
