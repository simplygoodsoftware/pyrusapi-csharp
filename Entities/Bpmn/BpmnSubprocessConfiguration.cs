using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class BpmnSubprocessConfiguration
	{
		[JsonProperty("subprocess_form_id")]
		public int SubprocessFormId { get; set; }

		[JsonProperty("wait_until_subprocess_finished")]
		public bool WaitUntilSubprocessFinished { get; set; }

		[JsonProperty("field_mappings")]
		public List<BpmnSubprocessFieldMapping> FieldMappings { get; set; }

		[JsonProperty("update_main_fields_mode")]
		public BpmnUpdateMainFieldsMode UpdateMainFieldsMode { get; set; }

		[JsonProperty("update_main_fields_on_step")]
		public int? UpdateMainFieldsOnStep { get; set; }

		[JsonProperty("finish_subprocess_tasks_when_main_is_finished")]
		public bool FinishSubprocessTasksWhenMainIsFinished { get; set; }

		[JsonProperty("subprocess_guid")]
		public string SubprocessGuid { get; set; }

		[JsonProperty("map_changes_only_on_subprocess_step")]
		public bool MapChangesOnlyOnSubprocessStep { get; set; }
	}
}
