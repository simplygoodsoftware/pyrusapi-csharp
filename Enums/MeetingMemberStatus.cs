using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pyrus.ApiClient.Enums
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum MeetingMemberStatus
	{
		[EnumMember(Value = "undefined")]
		Undefined,

		[EnumMember(Value = "going")]
		Going,

		[EnumMember(Value = "maybe")]
		MayBe,

		[EnumMember(Value = "not_going")]
		NotGoing,

		[EnumMember(Value = "going_virtually")]
		GoingVirtually,

		[EnumMember(Value = "going_to_meeting_room")]
		GoingToMeetingRoom,
	}
}
