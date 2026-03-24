using System;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class KnowledgeBaseAttachmentInfo
	{
		[JsonProperty("id")]
		public Guid Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("size")]
		public long Size { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }
	}
}
