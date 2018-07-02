using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormFieldAuthor : FormField
	{
		[JsonProperty("value")]
		public Person Value { get; set; }

		public override string ToString()
		{
			return Value == null 
				? ""
				: $"{Value.FirstName} {Value.LastName}";
		}
	}
}
