using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PyrusApiClient
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum SendSmsStatus
	{
		[EnumMember(Value = "sent")]
		Sent,

		[EnumMember(Value = "delivered")]
		Delivered,

		[EnumMember(Value = "delivery_failed")]
		DeliveryFailed,

		[EnumMember(Value = "send_failed")]
		SendFailed
	}
}
