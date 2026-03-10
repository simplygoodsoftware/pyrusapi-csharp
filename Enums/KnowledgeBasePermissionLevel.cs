using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Pyrus.ApiClient.Enums
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum KnowledgeBasePermissionLevel
	{
		[EnumMember(Value = "none")]
		None,

		[EnumMember(Value = "read")]
		Read,

		[EnumMember(Value = "write")]
		Write
	}
}
