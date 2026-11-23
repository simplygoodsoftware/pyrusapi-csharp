using Newtonsoft.Json;

namespace PyrusApiClient
{
	/// <summary>
	/// Settings for waiting for a node's approval or rejection within a specified duration.
	/// </summary>
	public class BpmnAwaitingNodeApproval
	{
		/// <summary>
		/// ID of the node whose approval or rejection is awaited.
		/// </summary>
		[JsonProperty("awaited_node_id")]
		public int AwaitedNodeId { get; set; }

		/// <summary>
		/// Maximum waiting duration.
		/// </summary>
		[JsonProperty("duration")]
		public BpmnTimer Duration { get; set; }
	}
}
