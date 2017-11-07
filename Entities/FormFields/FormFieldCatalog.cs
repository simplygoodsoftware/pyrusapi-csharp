using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormFieldCatalog : FormField
	{
		[JsonProperty("value")]
		public Catalog Value { get; set; }
	}

	public class Catalog
	{
		[JsonProperty("item_id")]
		public long ItemId { get; set; }

		[JsonProperty("headers")]
		public string[] Headers { get; set; }

		[JsonProperty("values")]
		public string[] Values { get; set; }
	}
}
