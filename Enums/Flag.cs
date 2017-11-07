using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PyrusApiClient
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum Flag
	{
		[EnumMember(Value = "none")]
		None,

		[EnumMember(Value = "checked")]
		Checked,

		[EnumMember(Value = "unchecked")]
		Unchecked
	}
}
