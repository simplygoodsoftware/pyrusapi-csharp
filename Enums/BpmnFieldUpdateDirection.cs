using System.Runtime.Serialization;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	[JsonConverter(typeof(StringEnumWithDefaultConverter), (int)Unknown)]
	public enum BpmnFieldUpdateDirection
	{
		[EnumMember(Value = "Unknown")]
		Unknown,

		[EnumMember(Value = "MainToSubprocess")]
		MainToSubprocess,

		[EnumMember(Value = "SubprocessToMain")]
		SubprocessToMain
	}
}
