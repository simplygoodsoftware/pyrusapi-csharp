using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public abstract class CatalogRequestBase
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("external_id")]
		public string ExternalId { get; set; }

		[JsonProperty("name")]
		public string CatalogName { get; set; }

		[JsonProperty("external_version")]
		public long ExternalVersion { get; set; }

		[JsonProperty("catalog_headers")]
		public List<string> CatalogHeaders { get; set; } = new List<string>();

		[JsonProperty("items")]
		public List<CatalogItem> Items { get; set; } = new List<CatalogItem>();

		[JsonProperty("add_supervisors")]
		public int[] AddSupervisors { get; set; }

		[JsonProperty("remove_supervisors")]
		public int[] RemoveSupervisors { get; set; }

		[JsonProperty("add_workflow_headers")]
		public List<string> AddWorkflowHeaders { get; set; }

		[JsonProperty("delete_workflow_headers")]
		public List<string> DeleteWorkflowHeaders { get; set; }

		[JsonProperty("column_settings")]
		public List<ColumnSettings> ColumnSettings { get; set; }
	}
}
