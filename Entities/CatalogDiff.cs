using Newtonsoft.Json;
using PyrusApiClient;
using System.Collections.Generic;

namespace Pyrus.ApiClient.Entities
{
	public class CatalogDiff
	{
		[JsonProperty("apply")]
		public bool Apply { get; set; }

		[JsonProperty("added")]
		public List<CatalogItem> Added { get; set; }

		[JsonProperty("deleted")]
		public List<CatalogItem> Deleted { get; set; }

		[JsonProperty("updated")]
		public List<CatalogItem> Updated { get; set; }

		[JsonProperty("catalog_headers")]
		public List<CatalogHeader> CatalogHeaders { get; set; }
	}
}
