using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormFieldStatus : FormField
	{
		[JsonProperty("value")]
		public Status? Value { get; set; }
	}
}
