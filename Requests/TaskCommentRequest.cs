using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	public class TaskCommentRequest
	{
		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("formatted_text")]
		public string FormattedText { get; set; }

		[JsonProperty("subject")]
		public string Subject { get; set; }

		[JsonProperty("approval_choice")]
		public ApprovalChoice? ApprovalChoice { get; set; }

		[JsonProperty("reassign_to")]
		public Person ReassignTo { get; set; }

		[JsonProperty("approval_steps")]
		public List<int> ApprovalSteps { get; set; } = new List<int>();

		[JsonProperty("action")]
		public ActivityAction? Action { get; set; }

		[JsonProperty("attachments")]
		public List<NewFile> Attachments { get; set; } = new List<NewFile>();

		[JsonProperty("field_updates")]
		public List<FormField> FieldUpdates { get; set; } = new List<FormField>();

		[JsonProperty("approvals_added")]
		public List<List<Person>> ApprovalsAdded { get; set; } = new List<List<Person>>();

		[JsonProperty("approvals_removed")]
		public List<List<Person>> ApprovalsRemoved { get; set; } = new List<List<Person>>();

		[JsonProperty("approvals_rerequested")]
		public List<List<Person>> ApprovalsRerequested { get; set; } = new List<List<Person>>();

		[JsonProperty("subscribers_added")]
		public List<Person> SubscribersAdded { get; set; } = new List<Person>();

		[JsonProperty("subscribers_removed")]
		public List<Person> SubscribersRemoved { get; set; } = new List<Person>();

		[JsonProperty("subscribers_rerequested")]
		public List<Person> SubscribersRerequested { get; set; } = new List<Person>();

		[JsonProperty("participants_added")]
		public List<Person> ParticipantsAdded { get; set; } = new List<Person>();

		[JsonProperty("participants_removed")]
		public List<Person> ParticipantsRemoved { get; set; } = new List<Person>();

		[JsonProperty("due_date")]
		[JsonConverter(typeof(DateTimeJsonConverter), Constants.DateFormat)]
		public DateTime? DueDate { get; set; }

		[JsonProperty("due")]
		[JsonConverter(typeof(DateTimeJsonConverter), Constants.DateTimeFormat)]
		public DateTime? Due { get; set; }

		[JsonProperty("duration")]
		public int? Duration { get; set; }
		
		[JsonProperty("scheduled_date")]
		[JsonConverter(typeof(DateTimeJsonConverter), Constants.DateFormat)]
		public DateTime? ScheduledDate { get; set; }

		[JsonProperty("scheduled_datetime_utc")]
		[JsonConverter(typeof(DateTimeJsonConverter), Constants.DateTimeFormat)]
		public DateTime? ScheduledDateTimeUtc { get; set; }

		[JsonProperty("cancel_schedule")]
		public bool? CancelSchedule { get; set; }

		[JsonProperty("added_list_ids")]
		public List<int> AddedListIds { get; set; } = new List<int>();

		[JsonProperty("removed_list_ids")]
		public List<int> RemovedListIds { get; set; } = new List<int>();

		[JsonProperty("channel")]
		public Channel Channel { get; set; }

		[JsonProperty("spent_minutes")]
		public int? SpentMinutes { get; set; }

		[JsonProperty("skip_satisfaction")]
		public bool? SkipSatisfactionRequest { get; set; }
	}
}
