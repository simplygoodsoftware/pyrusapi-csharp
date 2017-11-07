using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PyrusApiClient
{
	public class FormFieldStatus : FormField
	{
		[JsonProperty("value")]
		public Status? Value { get; set; }
	}
}
