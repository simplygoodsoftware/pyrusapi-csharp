using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class BpmnFieldVisibilityCondition
	{
		[JsonProperty("field_id")]
		public int FieldId { get; set; }

		[JsonProperty("condition")]
		public BpmnCondition Condition { get; set; }
	}
}
