using System.Runtime.Serialization;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	[JsonConverter(typeof(StringEnumWithDefaultConverter), (int)Unknown)]
	public enum BpmnFieldUpdateDirection
	{
		Unknown = -1,

		[EnumMember(Value = "MainToSubprocess")]
		MainToSubprocess = 0,

		[EnumMember(Value = "SubprocessToMain")]
		SubprocessToMain = 1
	}
}
