using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PyrusApiClient
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum SendSmsError
	{
		[EnumMember(Value = "none")]
		None,

		[EnumMember(Value = "unknown")]
		Unknown,

		[EnumMember(Value = "expired")]
		Expired,

		[EnumMember(Value = "forbidden")]
		Forbidden,

		[EnumMember(Value = "unreachable")]
		Unreachable,

		[EnumMember(Value = "unknown_status")]
		UnknownStatus,

		[EnumMember(Value = "unable_to_deliver")]
		UnableToDeliver,

		[EnumMember(Value = "invalid_phone_number")]
		InvalidPhoneNumber,

		[EnumMember(Value = "rejected")]
		Rejected
	}
}
