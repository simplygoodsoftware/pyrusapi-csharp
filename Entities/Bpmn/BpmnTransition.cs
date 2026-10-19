using Newtonsoft.Json;

namespace PyrusApiClient
{
	/// <summary>
	/// Перемещение BPMN-токена в результате комментария.
	/// </summary>
	/// <remarks>
	/// Если <see cref="NodeId"/> равен <c>null</c>, токен был удалён: известен только <see cref="TokenId"/>.
	/// При статусе <see cref="BpmnTokenStatus.Suspended"/> <see cref="NodeId"/> — узел, на котором процесс остановился.
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
