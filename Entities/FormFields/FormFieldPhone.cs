using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormFieldPhone : FormField
	{
		[JsonProperty("value")]
		public string Value { get; set; }
	}
}
