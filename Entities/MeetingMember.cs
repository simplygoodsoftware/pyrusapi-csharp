using Newtonsoft.Json;
using Pyrus.ApiClient.Enums;

namespace PyrusApiClient
{
	public class MeetingMember
	{
		[JsonProperty("person")]
		public MeetingPersonInfo Person { get; set; }

		[JsonProperty("status")]
		public MeetingMemberStatus Status { get; set; }
	}
}
