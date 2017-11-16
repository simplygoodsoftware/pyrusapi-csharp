using System;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	public class Task
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("create_date")]
		public DateTime CreateDate { get; set; }

		[JsonProperty("last_modified_date")]
		public DateTime LastModifiedDate { get; set; }

		[JsonProperty("author")]
		public Person Author { get; set; }

		[JsonProperty("due_date")]
		[JsonConverter(typeof(DateTimeJsonConverter), "yyyy-MM-dd")]
		public DateTime? DueDate { get; set; }

		[JsonProperty("due")]
		[JsonConverter(typeof(DateTimeJsonConverter), "yyyy-MM-ddTHH:mm:ssZ")]
		public DateTime? Due { get; set; }

		[JsonProperty("duration")]
		public int? Duration { get; set; }

		[JsonProperty("close_date")]
		public DateTime? CloseDate { get; set; }

		[JsonProperty("form_id")]
		public int? FormId { get; set; }
		
		[JsonProperty("attachments")]
		public File[] Attachments { get; set; }

		[JsonProperty("comments")]
		public TaskComment[] Comments { get; set; }
		
		[JsonProperty("responsible")]
		public Person Responsible { get; set; }

		[JsonProperty("fields")]
		public FormField[] Fields { get; set; }

		[JsonProperty("approvals")]
		public Approval[][] Approvals { get; set; }

		[JsonProperty("participants")]
		public Person[] Participants { get; set; }
	}
}
