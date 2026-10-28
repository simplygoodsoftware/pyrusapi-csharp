using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class BpmnWorkflowCatalogColumn
	{
		[JsonProperty("catalog_id")]
		public int CatalogId { get; set; }

		[JsonProperty("column_id")]
		public int ColumnId { get; set; }

		[JsonProperty("column_name")]
		public string ColumnName { get; set; }

		[JsonProperty("field_id")]
		public int? FieldId { get; set; }

		[JsonProperty("is_manager")]
		public bool IsManager { get; set; }
	}
}
