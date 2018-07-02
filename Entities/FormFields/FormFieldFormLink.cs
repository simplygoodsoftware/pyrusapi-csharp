using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormFieldFormLink : FormField
	{
		[JsonProperty("value")]
		public FormLink Value { get; set; }

		public override string ToString()
		{
			return Value?.Subject ?? "";
		}
	}
}
