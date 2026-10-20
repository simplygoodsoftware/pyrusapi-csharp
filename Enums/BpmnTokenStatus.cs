using System.Runtime.Serialization;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	/// <summary>
	/// Status of a BPMN token of a task.
	/// </summary>
	[JsonConverter(typeof(StringEnumWithDefaultConverter), (int)Unknown)]
	public enum BpmnTokenStatus
	{
		Unknown = -1,

		[EnumMember(Value = "Active")]
		Active = 0,

		[EnumMember(Value = "Waiting")]
		Waiting = 1,

		[EnumMember(Value = "Completed")]
		Completed = 2,

		[EnumMember(Value = "Suspended")]
		Suspended = 3,

		[EnumMember(Value = "Terminated")]
		Terminated = 4
	}
}
