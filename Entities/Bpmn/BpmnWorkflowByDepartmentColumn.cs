using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class BpmnWorkflowByDepartmentColumn
	{
		[JsonProperty("catalog_id")]
		public int CatalogId { get; set; }

		[JsonProperty("column_id")]
		public int ColumnId { get; set; }

		[JsonProperty("column_name")]
		public string ColumnName { get; set; }

		[JsonProperty("apply_to_task_author")]
		public bool ApplyToTaskAuthor { get; set; }

		[JsonProperty("contact_field_id")]
		public int? ContactFieldId { get; set; }
	}
}
