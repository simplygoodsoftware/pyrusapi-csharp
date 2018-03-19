using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;
using PyrusApiClient.Builders;

namespace PyrusApiClient
{
	public class TaskCommentRequest
	{
		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("approval_choice")]
		public ApprovalChoice? ApprovalChoice { get; set; }

		[JsonProperty("action")]
		public ActivityAction? Action { get; set; }

		[JsonProperty("attachments")]
		public List<string> Attachments { get; set; } = new List<string>();

		[JsonProperty("field_updates")]
		public List<FormField> FieldUpdates { get; set; } = new List<FormField>();

		[JsonProperty("approvals_added")]
		public List<List<Person>> ApprovalsAdded { get; set; } = new List<List<Person>>();

		[JsonProperty("approvals_removed")]
		public List<List<Person>> ApprovalsRemoved { get; set; } = new List<List<Person>>();

		[JsonProperty("participants_added")]
		public List<Person> ParticipantsAdded { get; set; } = new List<Person>();

		[JsonProperty("participants_removed")]
		public List<Person> ParticipantsRemoved { get; set; } = new List<Person>();

		[JsonProperty("due_date")]
		[JsonConverter(typeof(DateTimeJsonConverter), "yyyy-MM-dd")]
		public DateTime? DueDate { get; set; }

		[JsonProperty("due")]
		[JsonConverter(typeof(DateTimeJsonConverter), "yyyy-MM-ddTHH:mm:ssZ")]
		public DateTime? Due { get; set; }

		[JsonProperty("duration")]
		public int? Duration { get; set; }
		
		[JsonProperty("scheduled_date")]
		[JsonConverter(typeof(DateTimeJsonConverter), "yyyy-MM-dd")]
		public DateTime? ScheduledDate { get; set; }

		[JsonProperty("cancel_schedule")]
		public bool? CancelSchedule { get; set; }

		[JsonProperty("added_list_ids")]
		public List<int> AddedListIds { get; set; } = new List<int>();

		[JsonProperty("removed_list_ids")]
		public List<int> RemovedListIds { get; set; } = new List<int>();


	}
}
