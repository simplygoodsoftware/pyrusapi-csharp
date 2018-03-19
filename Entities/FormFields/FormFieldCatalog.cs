using System.Collections.Generic;
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
		public List<string> Headers { get; set; }

		[JsonProperty("values")]
		public List<string> Values { get; set; }

		public override string ToString()
		{
			return ItemId.ToString();
		}
	}
}
