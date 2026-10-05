using System.Runtime.Serialization;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	[JsonConverter(typeof(StringEnumWithDefaultConverter), (int)Unknown)]
	public enum BpmnParticipantAction
	{
		Unknown = -1,

		[EnumMember(Value = "Approve")]
		Approve = 1,

		[EnumMember(Value = "Reject")]
		Reject = 2,

		[EnumMember(Value = "Acknowledge")]
		Acknowledge = 4,

		[EnumMember(Value = "Complete")]
		Complete = 5,

		[EnumMember(Value = "Sign")]
		Sign = 6
	}
}
