using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class NewFileUrl : NewFile
	{
		[JsonProperty("url")]
		public string Url { get; set; }

		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
	}
}
