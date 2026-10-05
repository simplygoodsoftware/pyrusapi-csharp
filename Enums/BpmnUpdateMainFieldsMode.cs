using System.Runtime.Serialization;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	[JsonConverter(typeof(StringEnumWithDefaultConverter), (int)Unknown)]
	public enum BpmnUpdateMainFieldsMode
	{
		Unknown = -1,

		[EnumMember(Value = "Immediately")]
		Immediately = 0,

		[EnumMember(Value = "OnStep")]
		OnStep = 1
	}
}
