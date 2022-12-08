using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class CatalogItem
	{
		[JsonProperty("item_id")]
		public long Id { get; set; }

		[JsonProperty("external_id")]
		public long? ExternalId { get; set; }

		[JsonProperty("values")]
		public List<string> Values { get; set; } = new List<string>();

		[JsonProperty("deleted")]
		public bool Deleted { get; set; }
	}
}
