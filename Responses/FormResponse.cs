using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormResponse : ResponseBase
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("steps")]
		public Dictionary<int, string> Steps { get; set; }

		[JsonProperty("fields")]
		public List<FormField> Fields { get; set; }

		[JsonProperty("print_forms")]
		public List<PrintForm> PrintForms { get; set; }

		[JsonProperty("deleted_or_closed")]
		public bool DeletedOrClosed { get; set; }

		[JsonProperty("business_owners")]
		public int[] BusinessOwners { get; set; }

		[JsonProperty("folder")]
		public string[] Folder { get; set; }

		/// <summary>
		/// New tasks of the form are created and routed by the BPMN diagram.
		/// </summary>
		[JsonProperty("use_bpmn_for_new_tasks")]
		public bool UseBpmnForNewTasks { get; set; }

		/// <summary>
		/// Diagram version for new tasks. Returned only when UseBpmnForNewTasks == true.
		/// </summary>
		[JsonProperty("bpmn_version")]
		public int? BpmnVersion { get; set; }

		[JsonIgnore]
		public List<FormField> FlatFields => FieldHelper.GetFlatFieldsByForm(Fields);
	}
}
 