using System.Runtime.Serialization;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	[JsonConverter(typeof(StringEnumWithDefaultConverter), (int)Unknown)]
	public enum BpmnTimerMode
	{
		[EnumMember(Value = "Unknown")]
		Unknown,

		[EnumMember(Value = "RelativeTime")]
		RelativeTime,

		[EnumMember(Value = "RelativeOrgWorkTime")]
		RelativeOrgWorkTime
	}
}
