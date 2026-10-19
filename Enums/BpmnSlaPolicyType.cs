using System.Runtime.Serialization;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	/// <summary>
	/// Тип политики SLA: по этапам или по статусам.
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
