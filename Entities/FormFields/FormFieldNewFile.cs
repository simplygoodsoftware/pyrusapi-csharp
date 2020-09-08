using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormFieldNewFile : FormField
	{
		[JsonProperty("value")]
		public List<NewFile> Value { get; set; } = new List<NewFile>();
	}
}
