using System;
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
		public FormField[] FieldUpdates { get; set; }
		
		[JsonProperty("approval_choice")]
		public ApprovalChoice? ApprovalChoice { get; set; }

		[JsonProperty("reset_to_step")]
		public int? ResetToStep { get; set; }

		[JsonProperty("approvals_added")]
		public Approval[][] ApprovalsAdded { get; set; }

		[JsonProperty("approvals_removed")]
		public Approval[][] ApprovalsRemoved { get; set; }

		[JsonProperty("participants_added")]
		public Person[] ParticipantsAdded { get; set; }

		[JsonProperty("participants_removed")]
		public Person[] ParticipantsRemoved { get; set; }

		[JsonProperty("due_date")]
		[JsonConverter(typeof(DateTimeJsonConverter), "yyyy-MM-dd")]
		public DateTime? DueDate { get; set; }

		[JsonProperty("due")]
		[JsonConverter(typeof(DateTimeJsonConverter), "yyyy-MM-ddTHH:mm:ssZ")]
		public DateTime? Due { get; set; }

		[JsonProperty("duration")]
		public int? Duration { get; set; }

		[JsonProperty("attachments")]
		public File[] Attachments { get; set; }

		[JsonProperty("action")]
		public ActivityAction? Action { get; set; }
	}
}
