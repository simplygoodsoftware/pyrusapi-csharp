using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PyrusApiClient
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum ApprovalChoice
	{
		[EnumMember(Value = "waiting")]
		Waiting,

		[EnumMember(Value = "approved")]
		Approved,

		[EnumMember(Value = "rejected")]
		Rejected,

		[EnumMember(Value = "revoked")]
		Revoked
	}
}
