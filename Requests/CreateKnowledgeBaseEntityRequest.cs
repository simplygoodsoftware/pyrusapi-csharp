using Newtonsoft.Json;
using Pyrus.ApiClient.Enums;

namespace PyrusApiClient
{
	public class CreateKnowledgeBaseEntityRequest
	{
		[JsonProperty("type")]
		public KnowledgeBaseEntityType Type { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("body")]
		public string Body { get; set; }

		[JsonProperty("parent_topic_id")]
		public string ParentTopicId { get; set; }
	}
}
