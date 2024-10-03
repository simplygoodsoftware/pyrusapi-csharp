using System;
using System.Runtime.Serialization;

namespace Pyrus.ApiClient.Enums
{
	[DataContract]
	public enum MessengerType
	{
		[EnumMember]
		None = 0,

		[EnumMember]
		Telegram = 1,

		[EnumMember]
		WhatsApp = 2,

		[EnumMember]
		VK = 3,

		[EnumMember]
		Discord = 4,

		[EnumMember]
		Skype = 5,

		[EnumMember]
		Viber = 6,

		[EnumMember]
		Internet = 7,
	}
}
