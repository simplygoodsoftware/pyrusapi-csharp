using Newtonsoft.Json;

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
		public string[] Attachments { get; set; }

		[JsonProperty("field_updates")]
		public FormField[] FieldUpdates { get; set; }

		[JsonProperty("approvals_added")]
		public Person[][] ApprovalsAdded { get; set; }

		[JsonProperty("participants_added")]
		public Person[] ParticipantsAdded { get; set; }
	}
}
