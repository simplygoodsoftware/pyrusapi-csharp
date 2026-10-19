using System.Runtime.Serialization;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	/// <summary>
	/// Какой календарь используется при расчёте SLA: выключен, календарь формы или календарь организации.
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
