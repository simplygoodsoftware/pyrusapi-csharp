using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class Approval
	{
		[JsonProperty("person")]
		public Person Person { get; set; }

		[JsonProperty("approval_choice")]
		public ApprovalChoice? ApprovalChoice { get; set; }

		[JsonProperty("step")]
		public int? Step { get; set; }
	}
}
