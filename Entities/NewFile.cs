using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class NewFile
	{
		[JsonProperty("guid")]
		public string Guid { get; set; }

		[JsonProperty("root_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int? RootId { get; set; }
	}
}
