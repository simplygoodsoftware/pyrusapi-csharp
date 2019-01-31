using System.Runtime.Serialization;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	[JsonConverter(typeof(StringEnumWithDefaultConverter), (int)User)]
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
