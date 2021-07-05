using Newtonsoft.Json;
using PyrusApiClient;
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

		[JsonProperty("catalog_headers")]
		public List<CatalogHeader> Headers { get; set; }

		[JsonProperty("items")]
		public List<CatalogItem> Items { get; set; }
	}
}
