using System.Collections.Generic;
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
		public List<Person> Persons { get; set; } = new List<Person>();

		[JsonProperty("roles")]
		public List<Role> Roles { get; set; } = new List<Role>();

		[JsonProperty("department_catalog_id")]
		public int? DepartmentCatalogId { get; set; }
	}
}
