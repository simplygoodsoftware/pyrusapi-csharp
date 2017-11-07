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
		public ChoiceOption[] Options { get; set; }

		[JsonProperty("catalog_id")]
		public int? CatalogId { get; set; }

		[JsonProperty("columns")]
		public FormField[] Columns { get; set; }

		[JsonProperty("fields")]
		public FormField[] Fields { get; set; }

		[JsonProperty("form_id")]
		public int FormId { get; set; }
	}
	public class ChoiceOption
	{
		[JsonProperty("choice_id")]
		public int ChoiceId { get; set; }

		[JsonProperty("choice_value")]
		public string ChoiceValue { get; set; }

		[JsonProperty("fields")]
		public FormField[] Fields { get; set; }
	}
}
