using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormFieldTitle : FormField
	{
		[JsonProperty("value")]
		public Title Value { get; set; }
	}

	public class Title
	{
		[JsonProperty("checkmark")]
		public Checkmark? Checkmark { get; set; }

		[JsonProperty("fields")]
		public FormField[] Fields { get; set; }
	}
}
