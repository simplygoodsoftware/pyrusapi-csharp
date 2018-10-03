using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class UpdateCatalogResponse : ResponseBase
	{
		[JsonProperty(PropertyName = "apply")]
		public bool Apply { get; set; }

		[JsonProperty(PropertyName = "added")]
		public List<CatalogItem> Added { get; set; }

		[JsonProperty(PropertyName = "deleted")]
		public List<CatalogItem> Deleted { get; set; }

		[JsonProperty(PropertyName = "updated")]
		public List<CatalogItem> Updated { get; set; }

		[JsonProperty(PropertyName = "catalog_headers")]
		public List<CatalogHeader> CatalogHeaders { get; set; }
	}
}
