using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormFieldPerson : FormField
	{
		[JsonProperty("value")]
		public Person Value { get; set; }
	}
}
