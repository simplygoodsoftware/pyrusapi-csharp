using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormFieldInfo
	{
		[JsonProperty("required_step")]
		public int? RequiredStep { get; set; }

		[JsonProperty("immutable_step")]
		public int? ImmutableStep { get; set; }

		[JsonProperty("options")]
		public List<ChoiceOption> Options { get; set; } = new List<ChoiceOption>();

		[JsonProperty("catalog_id")]
		public int? CatalogId { get; set; }

		[JsonProperty("columns")]
		public List<FormField> Columns { get; set; } = new List<FormField>();

		[JsonProperty("fields")]
		public List<FormField> Fields { get; set; } = new List<FormField>();

		[JsonProperty("form_id")]
		public int FormId { get; set; }

		[JsonProperty("decimal_places")]
		public int? DecimalPlaces { get; set; }
	}
	public class ChoiceOption
	{
		[JsonProperty("choice_id")]
		public int ChoiceId { get; set; }

		[JsonProperty("choice_value")]
		public string ChoiceValue { get; set; }

		[JsonProperty("deleted")]
		public bool Deleted { get; set; }

		[JsonProperty("fields")]
		public List<FormField> Fields { get; set; } = new List<FormField>();
	}
}
