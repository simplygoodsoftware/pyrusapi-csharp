using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class BpmnParticipant
	{
		[JsonProperty("person")]
		public Person Person { get; set; }

		[JsonProperty("contact_field_id")]
		public int? ContactFieldId { get; set; }

		[JsonProperty("contact_field_form_field_id")]
		public int? ContactFieldFormFieldId { get; set; }

		[JsonProperty("queue_node_id")]
		public int? QueueNodeId { get; set; }

		[JsonProperty("workflow_catalog_column")]
		public BpmnWorkflowCatalogColumn WorkflowCatalogColumn { get; set; }

		[JsonProperty("workflow_by_department_column")]
		public BpmnWorkflowByDepartmentColumn WorkflowByDepartmentColumn { get; set; }
	}
}
