using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class KnowledgeBaseDeleteResponse : ResponseBase
	{
		[JsonProperty("deleted")]
		public bool Deleted { get; set; }
	}
}
