using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormFieldCatalog : FormField
	{
		[JsonProperty("value")]
		public Catalog Value { get; set; }

		public override string ToString()
		{
			return Value?.Rows == null || Value.Rows.Length == 0
				? ""
				: String.Join("; ", Value.Rows.Select(x => string.Join(", ", x)));
		}
	}

	public class Catalog
	{
		[Obsolete]
		[JsonProperty("item_id")]
		public long ItemId { get; set; }

		[JsonProperty("item_ids")]
		public long[] ItemIds { get; set; }

		[JsonProperty("headers")]
		public List<string> Headers { get; set; }

		[Obsolete]
		[JsonProperty("values")]
		public List<string> Values { get; set; }

		[JsonProperty("rows")]
		public string[][] Rows { get; set; }

		public override string ToString()
		{
			return ItemIds != null ? string.Join(", ", ItemIds) : "";
		}
	}
}
