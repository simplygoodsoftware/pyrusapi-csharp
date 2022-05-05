using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class AnnouncementComment
	{
		[JsonProperty("id")]
		public int Id { get; }

		[JsonProperty("text")]
		public string Text { get; }

		[JsonProperty("formatted_text")]
		public string FormattedText { get; }

		[JsonProperty("create_date")]
		public DateTime CreateDate { get; }

		[JsonProperty("author")]
		public Person Author { get; }

		[JsonProperty("attachments")]
		public List<File> Attachments { get; } = new List<File>();
		
		[JsonProperty("comments")]
		public List<TaskComment> Comments { get; } = new List<TaskComment>();
	}
}
