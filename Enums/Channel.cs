using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PyrusApiClient
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum Channel
	{
		[EnumMember(Value = "email")]
		Email ,

		[EnumMember(Value = "telegram")]
		Telegram,

		[EnumMember(Value = "web")]
		Web,

		[EnumMember(Value = "facebook")]
		Facebook,

		[EnumMember(Value = "vk")]
		Vk,

		[EnumMember(Value = "viber")]
		Viber,

		[EnumMember(Value = "mobile_app")]
		MobileApp,

		[EnumMember(Value = "web_widget")]
		WebWidget,

		[EnumMember(Value = "moy_sklad")]
		MoySklad,

		[EnumMember(Value = "zadarma")]
		Zadarma,

		[EnumMember(Value = "amo_crm")]
		AmoCrm,
	}
}
