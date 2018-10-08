using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class CatalogResponse : ResponseBase
	{
		[JsonProperty("catalog_id")]
		public int CatalogId { get; set; }

		[JsonProperty("items")]
		public List<CatalogItem> Items { get; set; }

		[JsonProperty("catalog_headers")]
		public List<CatalogHeader> Headers { get; set; }
	}
}
