using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class KnowledgeBaseStructureResponse : ResponseBase
	{
		[JsonProperty("parent_topic_id")]
		public string ParentTopicId { get; set; }

		[JsonProperty("depth")]
		public int? Depth { get; set; }

		[JsonProperty("items")]
		public List<KnowledgeBaseStructureItem> Items { get; set; }
	}
}
