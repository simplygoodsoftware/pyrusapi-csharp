using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Pyrus.ApiClient.Enums
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum PermissionLevel
	{
		[EnumMember(Value = "none")]
		None,

		[EnumMember(Value = "manager")]
		Manager,

		[EnumMember(Value = "member")]
		Member,

		[EnumMember(Value = "administrator")]
		Administrator
	}
}
