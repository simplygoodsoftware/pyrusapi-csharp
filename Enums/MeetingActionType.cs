using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pyrus.ApiClient.Enums
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum MeetingActionType
	{
		[EnumMember(Value = "added")]
		Added,

		[EnumMember(Value = "updated")]
		Updated,

		[EnumMember(Value = "deleted")]
		Deleted,
	}
}
