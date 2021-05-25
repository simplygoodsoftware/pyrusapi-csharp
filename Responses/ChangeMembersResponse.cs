using PyrusApiClient;
using System.Collections.Generic;

namespace Pyrus.ApiClient.Responses
{
	public class ChangeMembersResponse : ResponseBase
	{
		public List<Person> Members { get; set; } = new List<Person>();
		public List<string> Errors { get; set; } = new List<string>();
	}
}
