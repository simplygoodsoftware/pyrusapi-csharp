using System.Runtime.Serialization;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	[JsonConverter(typeof(StringEnumWithDefaultConverter), (int)Unknown)]
	public enum BpmnUpdateMainFieldsMode
	{
		[EnumMember(Value = "Unknown")]
		Unknown,

		[EnumMember(Value = "Immediately")]
		Immediately,

		[EnumMember(Value = "OnStep")]
		OnStep
	}
}
