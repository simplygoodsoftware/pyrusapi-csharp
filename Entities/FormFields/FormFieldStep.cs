using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormFieldStep : FormField
	{
		[JsonProperty("value")]
		public int? Value { get; set; }
	}
}
