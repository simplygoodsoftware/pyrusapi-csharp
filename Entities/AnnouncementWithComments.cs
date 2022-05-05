using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class AnnouncementWithComments
	{
		[JsonProperty("id")]
		public int Id { get; }

		[JsonProperty("text")]
		public string Text { get; }

		[JsonProperty("formatted_text")]
		public string FormattedText { get; }

		[JsonProperty("create_date")]
		public DateTime CreateDate { get; }

		[JsonProperty("last_modified_date")]
		public DateTime LastModifiedDate { get; }

		[JsonProperty("author")]
		public Person Author { get; }

		[JsonProperty("attachments")]
		public List<File> Attachments { get; } = new List<File>();
		
		[JsonProperty("comments")]
		public List<AnnouncementComment> Comments { get; } = new List<AnnouncementComment>();
	}
}
