using System.Runtime.Serialization;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	[JsonConverter(typeof(StringEnumWithDefaultConverter), (int)Unknown)]
	public enum BpmnNodeType
	{
		[EnumMember(Value = "Unknown")]
		Unknown,

		[EnumMember(Value = "Start")]
		Start,

		[EnumMember(Value = "Finish")]
		Finish,

		[EnumMember(Value = "XOR")]
		Xor,

		[EnumMember(Value = "AND_Split")]
		AndSplit,

		[EnumMember(Value = "AND_Join")]
		AndJoin,

		[EnumMember(Value = "Activity")]
		Activity,

		[EnumMember(Value = "Subprocess")]
		Subprocess,

		[EnumMember(Value = "Queue")]
		Queue,

		[EnumMember(Value = "Timer")]
		Timer,

		[EnumMember(Value = "AwaitingStatus")]
		AwaitingStatus
	}
}
