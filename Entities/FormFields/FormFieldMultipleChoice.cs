using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormFieldMultipleChoice : FormField
	{
		[JsonProperty("value")]
		public MultipleChoice Value { get; set; } = new MultipleChoice();

		public override string ToString()
		{
			return Value?.ChoiceId?.ToString() ?? "";
		}
	}

	public class MultipleChoice
	{
		[JsonProperty("choice_id")]
		public int? ChoiceId { get; set; }

		[JsonProperty("fields")]
		public List<FormField> Fields { get; set; } = new List<FormField>();
	}
}
