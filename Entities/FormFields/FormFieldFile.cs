using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormFieldFile : FormField
	{
		[JsonProperty("value")]
		public List<File> Value { get; set; }
	}
}
