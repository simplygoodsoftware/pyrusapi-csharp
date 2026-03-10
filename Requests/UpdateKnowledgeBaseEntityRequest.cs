using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class UpdateKnowledgeBaseEntityRequest
	{
		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("body")]
		public string Body { get; set; }

		[JsonProperty("parent_topic_id_changed")]
		public bool? ParentTopicIdChanged { get; set; }

		[JsonProperty("parent_topic_id")]
		public string ParentTopicId { get; set; }
	}
}
