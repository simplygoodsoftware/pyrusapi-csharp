using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	public class TaskComment
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }
		
		[JsonProperty("create_date")]
		public DateTime CreateDate { get; set; }

		[JsonProperty("author")]
		public Person Author { get; set; }

		[JsonProperty("reassigned_to")]
		public Person ReassignedPerson { get; set; }

		[JsonProperty("field_updates")]
		public List<FormField> FieldUpdates { get; set; } = new List<FormField>();

		[JsonProperty("approval_choice")]
		public ApprovalChoice? ApprovalChoice { get; set; }

		[JsonProperty("reset_to_step")]
		public int? ResetToStep { get; set; }

		[JsonProperty("approvals_added")]
		public List<List<Approval>> ApprovalsAdded { get; set; } = new List<List<Approval>>();

		[JsonProperty("approvals_removed")]
		public List<List<Approval>> ApprovalsRemoved { get; set; } = new List<List<Approval>>();

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

		[JsonProperty("scheduled_date")]
		[JsonConverter(typeof(DateTimeJsonConverter), "yyyy-MM-dd")]
		public DateTime? ScheduledDate { get; set; }

		[JsonProperty("cancel_schedule")]
		public bool? CancelSchedule { get; set; }

		[JsonProperty("duration")]
		public int? Duration { get; set; }

		[JsonProperty("attachments")]
		public List<File> Attachments { get; set; } = new List<File>();

		[JsonProperty("action")]
		public ActivityAction? Action { get; set; }

		[JsonProperty("added_list_ids")]
		public List<int> AddedListIds { get; set; } = new List<int>();

		[JsonProperty("removed_list_ids")]
		public List<int> RemvoedListIds { get; set; } = new List<int>();
	}
}
