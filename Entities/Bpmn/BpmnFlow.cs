using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class BpmnFlow
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("to_node_id")]
		public int ToNodeId { get; set; }

		[JsonProperty("condition")]
		public BpmnCondition Condition { get; set; }

		[JsonProperty("is_default")]
		public bool IsDefault { get; set; }

		[JsonProperty("vertex_no")]
		public int? VertexNo { get; set; }

		[JsonProperty("to_vertex_no")]
		public int? ToVertexNo { get; set; }

		[JsonProperty("hint_position")]
		public BpmnPosition HintPosition { get; set; }
	}
}
