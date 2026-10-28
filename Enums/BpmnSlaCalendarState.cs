using System.Runtime.Serialization;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	/// <summary>
	/// Which calendar is used to calculate SLA: off, the form calendar or the organization calendar.
	/// </summary>
	[JsonConverter(typeof(StringEnumWithDefaultConverter), (int)Unknown)]
	public enum BpmnSlaCalendarState
	{
		Unknown = -1,

		[EnumMember(Value = "Off")]
		Off = 0,

		[EnumMember(Value = "Active")]
		Active = 1,

		[EnumMember(Value = "ActiveOrg")]
		ActiveOrg = 2
	}
}
