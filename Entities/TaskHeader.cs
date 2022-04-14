using System;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class TaskHeader
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("formatted_text")]
		public string FormattedText { get; set; }

		[JsonProperty("create_date")]
		public DateTime CreateDate { get; set; }

		[JsonProperty("last_modified_date")]
		public DateTime LastModifiedDate { get; set; }

		[JsonProperty("author")]
		public Person Author { get; set; }

		[JsonProperty("close_date")]
		public DateTime? CloseDate { get; set; }

		[JsonProperty("responsible")]
		public Person Responsible { get; set; }

		[JsonProperty("due_date")]
		public DateTime? DueDate { get; set; }
	}
}
