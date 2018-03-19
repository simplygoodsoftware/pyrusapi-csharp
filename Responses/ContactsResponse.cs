using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class ContactsResponse : ResponseBase
	{
		[JsonProperty("organizations")]
		public List<Organization> Organizations { get; set; }
	}
}
