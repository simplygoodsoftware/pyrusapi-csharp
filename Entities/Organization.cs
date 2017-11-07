using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class Organization
	{
		[JsonProperty("organization_id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("persons")]
		public Person[] Persons { get; set; }

		public Role[] Roles { get; set; }
	}
}
