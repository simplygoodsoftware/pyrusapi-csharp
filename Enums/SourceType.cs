using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace PyrusApiClient
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum SourceType
	{
		[EnumMember(Value = "default")]
		Default = 0,

		[EnumMember(Value = "fill_table")]
		FillTable = 26
	}
}
