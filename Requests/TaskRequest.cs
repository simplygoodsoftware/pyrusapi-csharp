using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
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
		[JsonConverter(typeof(DateTimeJsonConverter), Constants.DateFormat)]
		public DateTime? DueDate { get; set; }

		[JsonProperty("due")]
		[JsonConverter(typeof(DateTimeJsonConverter), Constants.DateTimeFormat)]
		public DateTime? Due { get; set; }

		[JsonProperty("scheduled_date")]
		[JsonConverter(typeof(DateTimeJsonConverter), Constants.DateFormat)]
		public DateTime? ScheduledDate { get; set; }

		[JsonProperty("scheduled_date_time_utc")]
		[JsonConverter(typeof(DateTimeJsonConverter), Constants.DateTimeFormat)]
		public DateTime? ScheduledDateTimeUtc { get; set; }

		[JsonProperty("cancel_schedule")]
		public bool? CancelSchedule { get; set; }

		[JsonProperty("duration")]
		public int? Duration { get; set; }

		[JsonProperty("form_id")]
		public int? FormId { get; set; }

		[JsonProperty("attachments")]
		public List<NewFile> Attachments { get; set; } = new List<NewFile>();

		[JsonProperty("responsible")]
		public Person Responsible { get; set; }

		[JsonProperty("fields")]
		public List<FormField> Fields { get; set; } = new List<FormField>();

		[JsonProperty("approvals")]
		public List<List<Person>> Approvals { get; set; } = new List<List<Person>>();

		[JsonProperty("participants")]
		public List<Person> Participants { get; set; } = new List<Person>();

		[JsonProperty("list_ids")]
		public List<int> ListIds { get; set; } = new List<int>();

		[JsonProperty("fill_defaults")]
		public bool FillDefaults { get; set; }
	}
}