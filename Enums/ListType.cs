using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PyrusApiClient
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum ListType
	{
		[EnumMember(Value = "private")]
		Private,

		[EnumMember(Value = "org_wide")]
		OrganizationWide
	}
}
