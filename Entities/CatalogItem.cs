using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class CatalogItem
	{
		[JsonProperty("item_id")]
		public long Id { get; set; }

		[JsonProperty("values")]
		public string[] Values { get; set; }
	}
}
