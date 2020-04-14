using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class CreateRoleRequest
	{
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "external_id")]
		public string ExternalId { get; set; }

		[JsonProperty(PropertyName = "member_add")]
		public List<int> Members { get; set; } = new List<int>();
	}
}
