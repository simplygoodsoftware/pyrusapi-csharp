using Newtonsoft.Json;
using System.Collections.Generic;

namespace PyrusApiClient
{
	public class CatalogResponse : ResponseBase
	{
		[JsonProperty("catalog_id")]
		public int CatalogId { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("external_id")]
		public string ExternalId { get; set; }

		[JsonProperty("version")]
		public long Version { get; set; }

		[JsonProperty("external_version")]
		public long ExternalVersion { get; set; }

		[JsonProperty("deleted")]
		public bool Deleted { get; set; }

		[JsonProperty("supervisors")]
		public List<int> Supervisors { get; set; }

		[JsonProperty("catalog_headers")]
		public List<CatalogHeader> Headers { get; set; }

		[JsonProperty("column_settings")]
		public List<ColumnSettings> ColumnSettings { get; set; }

		[JsonProperty("items")]
		public List<CatalogItem> Items { get; set; }

		[JsonProperty("source_type")]
		public SourceType SourceType { get; set; }
	}
}
