using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PyrusApiClient
{
	public class FormField
	{
		[JsonProperty("id")]
		public int? Id { get; set; }

		[JsonProperty("type")]
		[JsonConverter(typeof(StringEnumConverter))]
		public FormFieldType? Type { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("info")]
		public FormFieldInfo Info { get; set; }
	}
}
