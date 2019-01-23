using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PyrusApiClient
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum PersonType
	{
		[EnumMember(Value = "user")]
		User,
		[EnumMember(Value = "bot")]
		Bot,
		[EnumMember(Value = "role")]
		Role
	}
}
