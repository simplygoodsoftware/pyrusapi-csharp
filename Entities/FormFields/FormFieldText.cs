using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormFieldText : FormField
	{
		[JsonProperty("value")]
		public string Value { get; set; }

		public override string ToString()
		{
			return Value ?? "";
		}
	}
}
