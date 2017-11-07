using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormFieldNumber : FormField
	{
		[JsonProperty("value")]
		public decimal? Value { get; set; }
	}
}
