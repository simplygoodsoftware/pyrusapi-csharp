using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormFieldMoney : FormField
	{
		[JsonProperty("value")]
		public decimal? Value { get; set; }
	}
}
