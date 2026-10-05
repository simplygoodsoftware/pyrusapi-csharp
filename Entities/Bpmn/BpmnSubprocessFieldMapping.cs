using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class BpmnSubprocessFieldMapping
	{
		[JsonProperty("local_id")]
		public int? FieldLocalId { get; set; }

		[JsonProperty("subprocess_field_local_id")]
		public int? SubprocessFieldLocalId { get; set; }

		[JsonProperty("direction")]
		public BpmnFieldUpdateDirection Direction { get; set; }

		[JsonProperty("is_constant")]
		public bool IsConstant { get; set; }

		[JsonProperty("constant_value")]
		public BpmnSubprocessConstantValue ConstantValue { get; set; }
	}
}
