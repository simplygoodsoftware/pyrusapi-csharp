using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PyrusApiClient
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum MeetingType
	{
		[EnumMember(Value = "none")]
		None,

		[EnumMember(Value = "zoom")]
		Zoom,

		[EnumMember(Value = "offline")]
		Offline,

		[EnumMember(Value = "google_meet")]
		GoogleMeet,

		[EnumMember(Value = "yandex_telemost")]
		YandexTelemost,
	}
}
