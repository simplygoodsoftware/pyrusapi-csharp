using Newtonsoft.Json;

namespace PyrusApiClient
{
	/// <summary>
	/// Move of a BPMN token as a result of a comment.
	/// </summary>
	/// <remarks>
	/// If <see cref="NodeId"/> is <c>null</c>, the token was removed: only <see cref="TokenId"/> is known.
	/// With the <see cref="BpmnTokenStatus.Suspended"/> status, <see cref="NodeId"/> is the node where the process stopped.
	/// </remarks>
	public class BpmnTransition
	{
		[JsonProperty("token_id")]
		public int TokenId { get; set; }

		[JsonProperty("node_id")]
		public int? NodeId { get; set; }

		[JsonProperty("node_name")]
		public string NodeName { get; set; }

		[JsonProperty("node_type")]
		public BpmnNodeType? NodeType { get; set; }

		[JsonProperty("status")]
		public BpmnTokenStatus? Status { get; set; }
	}
}
