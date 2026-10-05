using System.Runtime.Serialization;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	[JsonConverter(typeof(StringEnumWithDefaultConverter), (int)Unknown)]
	public enum BpmnTimerMode
	{
		Unknown = -1,

		[EnumMember(Value = "RelativeTime")]
		RelativeTime = 0,

		[EnumMember(Value = "RelativeOrgWorkTime")]
		RelativeOrgWorkTime = 1
	}
}
