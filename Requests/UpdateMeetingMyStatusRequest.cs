using Newtonsoft.Json;
using Pyrus.ApiClient.Enums;

namespace PyrusApiClient
{
	public class UpdateMeetingMyStatusRequest
	{
		[JsonProperty("status")]
		public MeetingMemberStatus Status { get; set; }
	}
}
