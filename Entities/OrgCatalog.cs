using Newtonsoft.Json;
using System.Collections.Generic;

namespace Pyrus.ApiClient.Entities
{
	public class OrgCatalog
	{
		[JsonProperty("catalog_id")]
		public int CatalogId { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("external_id")]
		public string ExternalId { get; set; }

		[JsonProperty("version")]
		public long Version { get; set; }

		[JsonProperty("external_version")]
		public long ExternalVersion { get; set; }

		[JsonProperty("deleted")]
		public bool Deleted { get; set; }

		[JsonProperty("supervisors")]
		public List<int> Supervisors { get; set; }
	}
}
