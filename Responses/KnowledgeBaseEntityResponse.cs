using System;
using Newtonsoft.Json;
using Pyrus.ApiClient.Enums;

namespace PyrusApiClient
{
	public class KnowledgeBaseEntityResponse : ResponseBase
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("type")]
		public KnowledgeBaseEntityType Type { get; set; }

		[JsonProperty("body")]
		public string Body { get; set; }

		[JsonProperty("parent_topic_id")]
		public string ParentTopicId { get; set; }

		[JsonProperty("author")]
		public KnowledgeBasePersonInfo Author { get; set; }

		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; set; }

		[JsonProperty("updated_at")]
		public DateTime UpdatedAt { get; set; }

		[JsonProperty("last_edited_by")]
		public KnowledgeBasePersonInfo LastEditedBy { get; set; }

		[JsonProperty("version")]
		public long Version { get; set; }

		[JsonProperty("access_right")]
		public KnowledgeBasePermissionLevel AccessRight { get; set; }

		[JsonProperty("is_open_for_organization")]
		public bool IsOpenForOrganization { get; set; }

		[JsonProperty("is_public")]
		public bool IsPublic { get; set; }
	}
}
