using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class CatalogResponse : ResponseBase
	{
		[JsonProperty("catalog_id")]
		public int CatalogId { get; set; }

		[JsonProperty("items")]
		public CatalogItem[] Items { get; set; }
	}
}
