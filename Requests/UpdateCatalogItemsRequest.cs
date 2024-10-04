#nullable enable

using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	/// <summary>
	/// Contains catalog item collections to upsert and/or delete.
	/// </summary>
	public class UpdateCatalogItemsRequest
	{
		/// <summary>
		/// Catalog items to be added and/or updated.
		/// </summary>
		[JsonProperty(PropertyName = "upsert")]
		public List<CatalogItem>? UpsertItems { get; set; }

		/// <summary>
		/// Unique catalog item keys (values of the first column) to be deleted.
		/// </summary>
		[JsonProperty(PropertyName = "delete")]
		public HashSet<string>? DeleteItems { get; set; }
	}
}

#nullable disable
