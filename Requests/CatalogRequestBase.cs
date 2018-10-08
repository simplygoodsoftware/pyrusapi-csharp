using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public abstract class CatalogRequestBase
	{
		[JsonProperty(PropertyName = "catalog_headers")]
		public List<string> CatalogHeaders { get; set; } = new List<string>();

		[JsonProperty(PropertyName = "items")]
		public List<CatalogItem> Items { get; set; } = new List<CatalogItem>();
	}
}
