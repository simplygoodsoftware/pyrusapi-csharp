using System;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;
using PyrusApiClient;

namespace Pyrus.ApiClient.Requests
{
	public class TaskRequest
	{
		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("subject")]
		public string Subject { get; set; }

		[JsonProperty("parent_task_id")]
		public int? ParentTaskId { get; set; }

		[JsonProperty("due_date")]
		[JsonConverter(typeof(DateTimeJsonConverter), "yyyy-MM-dd")]
		public DateTime? DueDate { get; set; }

		[JsonProperty("due")]
		[JsonConverter(typeof(DateTimeJsonConverter), "yyyy-MM-ddTHH:mm:ssZ")]
		public DateTime? Due { get; set; }

		[JsonProperty("duration")]
		public int? Duration { get; set; }

		[JsonProperty("form_id")]
		public int? FormId { get; set; }

		[JsonProperty("attachments")]
		public string[] Attachments { get; set; }

		[JsonProperty("responsible")]
		public Person Responsible { get; set; }

		[JsonProperty("fields")]
		public FormField[] Fields { get; set; }

		[JsonProperty("approvals")]
		public Approval[][] Approvals { get; set; }

		[JsonProperty("participants")]
		public Person[] Participants { get; set; }

		[JsonProperty("lists")]
		public int[] Lists { get; set; }
	}
}
