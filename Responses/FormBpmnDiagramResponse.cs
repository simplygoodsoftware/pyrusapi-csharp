using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	public class FormBpmnDiagramResponse : ResponseBase
	{
		[JsonProperty("form_id")]
		public int FormId { get; set; }

		[JsonProperty("bpmn_version")]
		public int BpmnVersion { get; set; }

		[JsonProperty("active_bpmn_version")]
		public int? ActiveBpmnVersion { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("create_date")]
		[JsonConverter(typeof(DateTimeJsonConverter), Constants.DateTimeFormat)]
		public DateTime? CreateDate { get; set; }

		[JsonProperty("delete_date")]
		[JsonConverter(typeof(DateTimeJsonConverter), Constants.DateTimeFormat)]
		public DateTime? DeleteDate { get; set; }

		[JsonProperty("author")]
		public Person Author { get; set; }

		[JsonProperty("active_task_nodes")]
		public List<int> ActiveTaskNodes { get; set; }

		[JsonProperty("nodes")]
		public List<BpmnNode> Nodes { get; set; }

		[JsonProperty("deleted_nodes")]
		public List<BpmnNode> DeletedNodes { get; set; }

		[JsonProperty("field_visibility_conditions")]
		public List<BpmnFieldVisibilityCondition> FieldVisibilityConditions { get; set; }

		[JsonProperty("frames")]
		public List<BpmnFrame> Frames { get; set; }
	}
}
