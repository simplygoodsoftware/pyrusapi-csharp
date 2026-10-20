using Newtonsoft.Json;

namespace PyrusApiClient
{
	/// <summary>
	/// Manual move of a BPMN token to the given node (the bpmn_token_moves command in a comment).
	/// </summary>
	public class BpmnTokenMove
	{
		[JsonProperty("token_id")]
		public int TokenId { get; set; }

		[JsonProperty("node_id")]
		public int NodeId { get; set; }
	}
}
