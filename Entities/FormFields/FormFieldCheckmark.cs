using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormFieldCheckmark : FormField
	{
		[JsonProperty("value")]
		public Checkmark? Value { get; set; }
	}
}
