using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormFieldMultipleChoice : FormField
	{
		[JsonProperty("value")]
		public MultipleChoice Value { get; set; }
	}

	public class MultipleChoice
	{
		[JsonProperty("choice_id")]
		public int? ChoiceId { get; set; }

		[JsonProperty("fields")]
		public FormField[] Fields { get; set; }
	}
}
