using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormFieldTitle : FormField
	{
		[JsonProperty("value")]
		public Title Value { get; set; } = new Title();
	}

	public class Title
	{
		[JsonProperty("checkmark")]
		public Checkmark? Checkmark { get; set; }

		[JsonProperty("fields")]
		public List<FormField> Fields { get; set; } = new List<FormField>();
	}
}
