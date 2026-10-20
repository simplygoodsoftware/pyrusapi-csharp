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

		/// <summary>
		/// Version of the BPMN diagram the task follows.
		/// </summary>
		/// <remarks>
		/// Filled only in the get task response (GET /tasks/{id}) and in comment responses.
		/// Not returned in the form register, in the calendar and in bot webhooks (if SendBpmnInfoToWebhooks is off for the form),
		/// so null does not mean the task is not a BPMN task.
		/// </remarks>
		[JsonProperty("bpmn_version")]
		public int? BpmnVersion { get; set; }

		/// <summary>
		/// The task has suspended BPMN flows.
		/// </summary>
		/// <remarks>
		/// In GET /tasks/{id} and in comment responses it is always returned for BPMN tasks. In the form register it is returned only
		/// when true, so null there does not mean false. Not returned in the calendar and in bot webhooks (if
		/// SendBpmnInfoToWebhooks is off for the form).
		/// </remarks>
		[JsonProperty("bpmn_suspended")]
		public bool? BpmnSuspended { get; set; }

		/// <summary>
		/// Current state of the BPMN tokens of the task.
		/// </summary>
		/// <remarks>
		/// Filled only in GET /tasks/{id} and in comment responses. Not returned in the form register, in the calendar and in bot webhooks
		/// (if SendBpmnInfoToWebhooks is off for the form).
		/// </remarks>
		[JsonProperty("bpmn_tokens")]
		public List<BpmnToken> BpmnTokens { get; set; }

		[JsonIgnore]
		public List<FormField> FlatFields => FieldHelper.GetFlatFieldsListByTask(Fields);
	}
}
