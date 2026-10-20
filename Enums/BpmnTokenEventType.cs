using System.Runtime.Serialization;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	/// <summary>
	/// Type of the event a BPMN token is waiting for.
	/// </summary>
	[JsonConverter(typeof(StringEnumWithDefaultConverter), (int)Unknown)]
	public enum BpmnTokenEventType
	{
		Unknown = -1,

		[EnumMember(Value = "Timer")]
		Timer = 0,

		[EnumMember(Value = "AwaitingStatus")]
		AwaitingStatus = 1
	}
}
