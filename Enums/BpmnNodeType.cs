using System.Runtime.Serialization;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	[JsonConverter(typeof(StringEnumWithDefaultConverter), (int)Unknown)]
	public enum BpmnNodeType
	{
		Unknown = -1,

		[EnumMember(Value = "Start")]
		Start = 0,

		[EnumMember(Value = "Finish")]
		Finish = 1,

		[EnumMember(Value = "XOR")]
		Xor = 2,

		[EnumMember(Value = "AND_Split")]
		AndSplit = 3,

		[EnumMember(Value = "AND_Join")]
		AndJoin = 4,

		[EnumMember(Value = "Activity")]
		Activity = 5,

		[EnumMember(Value = "Subprocess")]
		Subprocess = 6,

		[EnumMember(Value = "Queue")]
		Queue = 7,

		[EnumMember(Value = "Timer")]
		Timer = 8,

		[EnumMember(Value = "AwaitingStatus")]
		AwaitingStatus = 9
	}
}
