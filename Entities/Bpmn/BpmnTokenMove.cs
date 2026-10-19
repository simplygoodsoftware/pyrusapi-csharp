using Newtonsoft.Json;

namespace PyrusApiClient
{
	/// <summary>
	/// Ручное перемещение BPMN-токена на указанный узел (команда bpmn_token_moves в комментарии).
	/// </summary>
	public class BpmnTokenMove
	{
		[JsonProperty("token_id")]
		public int TokenId { get; set; }

		[JsonProperty("node_id")]
		public int NodeId { get; set; }
	}
}
