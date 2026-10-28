using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	/// <summary>
	/// A set of SLA rules for a group of nodes. An empty set of rules means SLA is not limited on the step.
	/// </summary>
	public class BpmnSlaStepPolicySet
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("node_ids")]
		public List<int> NodeIds { get; set; }

		[JsonProperty("sla_policies")]
		public List<BpmnSlaPolicy> Policies { get; set; }
	}
}
