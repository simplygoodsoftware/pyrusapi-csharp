using System.Runtime.Serialization;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	/// <summary>
	/// SLA policy type: by step or by status.
	/// </summary>
	[JsonConverter(typeof(StringEnumWithDefaultConverter), (int)Unknown)]
	public enum BpmnSlaPolicyType
	{
		Unknown = -1,

		[EnumMember(Value = "ByStep")]
		ByStep = 0,

		[EnumMember(Value = "ByStatus")]
		ByStatus = 1
	}
}
