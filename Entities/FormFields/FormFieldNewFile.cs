using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormFieldNewFile : FormField
	{
		[JsonProperty("value")]
		public List<NewFile> Value { get; set; } = new List<NewFile>();
	}

	public class NewFile
	{
		[JsonProperty("guid")]
		public string Guid { get; set; }

		[JsonProperty("root_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int? RootId { get; set; }
	}
}
