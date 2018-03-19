using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormFieldNewFile : FormField
	{
		[JsonProperty("value")]
		public List<string> Value { get; set; } = new List<string>();
	}
}
