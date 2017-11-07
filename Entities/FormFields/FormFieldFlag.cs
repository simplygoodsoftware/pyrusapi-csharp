using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PyrusApiClient
{
	public class FormFieldFlag : FormField
	{
		[JsonProperty("value")]
		public Flag? Value { get; set; }
	}
}
