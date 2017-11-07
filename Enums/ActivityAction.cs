using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PyrusApiClient
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum ActivityAction
	{
		[EnumMember(Value = "finished")]
		Finished,

		[EnumMember(Value = "reopened")]
		Reopened
	}
}
