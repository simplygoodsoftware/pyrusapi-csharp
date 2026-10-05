using System.Runtime.Serialization;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	[JsonConverter(typeof(StringEnumWithDefaultConverter), (int)Unknown)]
	public enum BpmnParticipantAction
	{
		[EnumMember(Value = "Unknown")]
		Unknown,

		[EnumMember(Value = "Approve")]
		Approve,

		[EnumMember(Value = "Reject")]
		Reject,

		[EnumMember(Value = "Acknowledge")]
		Acknowledge,

		[EnumMember(Value = "Complete")]
		Complete,

		[EnumMember(Value = "Sign")]
		Sign
	}
}
