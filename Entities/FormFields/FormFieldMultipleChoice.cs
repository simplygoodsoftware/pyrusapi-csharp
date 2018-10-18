using System;
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
			return Value?.ChoiceIds?.Length > 0
				? String.Join(", ", Value.ChoiceIds)
				: Value?.ChoiceId?.ToString() ?? "";
		}
	}

	public class MultipleChoice
	{
		[JsonProperty("choice_id")]
		[Obsolete]
		public int? ChoiceId { get; set; }

		[JsonProperty("choice_ids")]
		public int[] ChoiceIds { get; set; }

		[JsonProperty("fields")]
		public List<FormField> Fields { get; set; } = new List<FormField>();
	}
}
