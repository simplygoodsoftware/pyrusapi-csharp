using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class BpmnNode
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("node_type")]
		public BpmnNodeType NodeType { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("participant")]
		public BpmnParticipant Participant { get; set; }

		[JsonProperty("subprocess_configuration")]
		public BpmnSubprocessConfiguration SubprocessConfiguration { get; set; }

		[JsonProperty("timer")]
		public BpmnTimer Timer { get; set; }

		[JsonProperty("awaiting_statuses")]
		public List<int> AwaitingStatuses { get; set; }

		[JsonProperty("task_status")]
		public int? TaskStatus { get; set; }

		[JsonProperty("actions")]
		public List<BpmnParticipantAction> Actions { get; set; }

		[JsonProperty("reference_node_id")]
		public int? ReferenceNodeId { get; set; }

		[JsonProperty("flow_group_id")]
		public int? FlowGroupId { get; set; }

		[JsonProperty("position")]
		public BpmnPosition Position { get; set; }

		[JsonProperty("flows")]
		public List<BpmnFlow> Flows { get; set; }

		[JsonProperty("deleted_flows")]
		public List<BpmnFlow> DeletedFlows { get; set; }
	}
}
