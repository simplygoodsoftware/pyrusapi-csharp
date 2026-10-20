using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	/// <summary>
	/// SLA settings of a BPMN diagram. Returned only if SLA was ever configured on the diagram.
	/// </summary>
	public class BpmnSla
	{
		[JsonProperty("enabled")]
		public bool Enabled { get; set; }

		[JsonProperty("sla_calendar_info")]
		public BpmnSlaCalendar Calendar { get; set; }

		[JsonProperty("sla_accumulate_time_on_step")]
		public bool? AccumulateTimeOnStep { get; set; }

		[JsonProperty("sla_policy_type")]
		public BpmnSlaPolicyType? PolicyType { get; set; }

		[JsonProperty("sla_policies")]
		public List<BpmnSlaPolicy> Policies { get; set; }

		[JsonProperty("sla_status_policies")]
		public List<BpmnSlaPolicy> StatusPolicies { get; set; }

		[JsonProperty("sla_default_step_policies")]
		public List<BpmnSlaPolicy> DefaultStepPolicies { get; set; }

		[JsonProperty("sla_step_policy_sets")]
		public List<BpmnSlaStepPolicySet> StepPolicySets { get; set; }
	}
}
