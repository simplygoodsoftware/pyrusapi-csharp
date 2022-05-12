using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class AnnouncementComment
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("formatted_text")]
		public string FormattedText { get; set; }

		[JsonProperty("create_date")]
		public DateTime CreateDate { get; set; }

		[JsonProperty("author")]
		public Person Author { get; set; }

		[JsonProperty("attachments")]
		public List<File> Attachments { get; set; } = new List<File>();
		
		[JsonProperty("comments")]
		public List<TaskComment> Comments { get; set; } = new List<TaskComment>();
	}
}
