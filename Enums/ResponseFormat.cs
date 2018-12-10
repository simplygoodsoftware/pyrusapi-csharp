using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PyrusApiClient
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum ResponseFormat
	{
		[EnumMember(Value = "json")]
		Json,

		[EnumMember(Value = "csv")]
		Csv
	}
}
