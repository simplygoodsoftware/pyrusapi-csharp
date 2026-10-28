using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class BpmnCondition
	{
		[JsonProperty("field_id")]
		public int FieldId { get; set; }

		[JsonProperty("condition_type")]
		public BpmnConditionType ConditionType { get; set; }

		[JsonProperty("value")]
		public string Value { get; set; }

		[JsonProperty("values")]
		public List<string> Values { get; set; }

		[JsonProperty("catalog_column")]
		public int? CatalogColumn { get; set; }

		[JsonProperty("children")]
		public List<BpmnCondition> Children { get; set; }
	}
}
