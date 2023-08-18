using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	public class Task : TaskHeader
	{
		[JsonProperty("due_date")]
		[JsonConverter(typeof(DateTimeJsonConverter), Constants.DateFormat)]
		public DateTime? DueDate { get; set; }

		[JsonProperty("due")]
		[JsonConverter(typeof(DateTimeJsonConverter), Constants.DateTimeFormat)]
		public DateTime? Due { get; set; }

		[JsonProperty("scheduled_date")]
		[JsonConverter(typeof(DateTimeJsonConverter), Constants.DateFormat)]
		public DateTime? ScheduledDate { get; set; }

		[JsonProperty("scheduled_datetime_utc")]
		[JsonConverter(typeof(DateTimeJsonConverter), Constants.DateTimeFormat)]
		public DateTime? ScheduledDateTimeUtc { get; set; }

		[JsonProperty("cancel_schedule")]
		public bool? CancelSchedule { get; set; }

		[JsonProperty("duration")]
		public int? Duration { get; set; }

		[JsonProperty("form_id")]
		public int? FormId { get; set; }
		
		[JsonProperty("attachments")]
		public List<File> Attachments { get; set; } = new List<File>();

		[JsonProperty("fields")]
		[JsonConverter(typeof(FormFieldListJsonConverter))]
		public List<FormField> Fields { get; set; } = new List<FormField>();

		[JsonProperty("approvals")]
		public List<List<Approval>> Approvals { get; set; } = new List<List<Approval>>();

		[JsonProperty("subscribers")]
		public List<Subscriber> Subscribers { get; set; } = new List<Subscriber>();

		[JsonProperty("participants")]
		public List<Person> Participants { get; set; } = new List<Person>();
		
		[JsonProperty("list_ids")]
		public List<int> ListIds { get; set; } = new List<int>();

		[JsonProperty("linked_task_ids")]
		public List<int> LinkedTaskIds { get; set; }

		[JsonProperty("parent_task_id")]
		public int? ParentTaskId { get; set; }

		[JsonProperty("last_note_id")]
		public long? LastNoteId { get; set; }

		[JsonProperty("subject")]
		public string Subject { get; set; }

		[JsonProperty("current_step")]
		public int? CurrentStep { get; set; }
		
		[JsonProperty("is_closed")]
		public bool IsClosed { get; set; }

		[JsonIgnore]
		public List<FormField> FlatFields => FieldHelper.GetFlatFieldsListByTask(Fields);
	}
}
