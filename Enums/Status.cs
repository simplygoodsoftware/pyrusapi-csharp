using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PyrusApiClient
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum Status
	{
		[EnumMember(Value = "open")]
		Open,

		[EnumMember(Value = "closed")]
		Closed
	}
}
