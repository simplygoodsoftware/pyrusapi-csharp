using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	/// <summary>
	/// Набор правил SLA для группы узлов. Пустой набор правил означает, что SLA на этапе не ограничивается.
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
