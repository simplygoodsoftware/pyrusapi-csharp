using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormFieldFlag : FormField
	{
		[JsonProperty("value")]
		public Flag? Value { get; set; }
	}
}
