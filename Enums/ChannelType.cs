using System.Runtime.Serialization;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	[JsonConverter(typeof(StringEnumWithDefaultConverter), (int)Unknown)]
	public enum ChannelType
	{
		Unknown = 0,

		[EnumMember(Value = "email")]
		Email = 1,

		[EnumMember(Value = "telegram")]
		Telegram = 2,

		[EnumMember(Value = "web")]
		Web = 3,

		[EnumMember(Value = "facebook")]
		Facebook = 4,

		[EnumMember(Value = "vk")]
		Vk = 5,

		[EnumMember(Value = "viber")]
		Viber = 6,

		[EnumMember(Value = "mobile_app")]
		MobileApp = 7,

		[EnumMember(Value = "web_widget")]
		WebWidget = 8,

		[EnumMember(Value = "moy_sklad")]
		MoySklad = 9,

		[EnumMember(Value = "zadarma")]
		Zadarma = 10,

		[EnumMember(Value = "amo_crm")]
		AmoCrm = 11,

		[EnumMember(Value = "instagram")]
		Instagram = 12,

		[EnumMember(Value = "private_channel")]
		PrivateChannel = 13,

		[EnumMember(Value = "jira")]
		Jira = 14,

		[EnumMember(Value = "beeline")]
		Beeline = 15,

		[EnumMember(Value = "api_telephony")]
		ApiTelephony = 16,

		[EnumMember(Value = "zoom")]
		Zoom = 17,

		[EnumMember(Value = "web_form")]
		WebForm = 18,

		[EnumMember(Value = "whats_app")]
		WhatsApp = 19,

		[EnumMember(Value = "custom")]
		Custom = 20,
		
		[EnumMember(Value = "sms")]
		Sms = 21
	}
}
