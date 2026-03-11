using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Pyrus.ApiClient.Enums
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum KnowledgeBaseEntityType
	{
		[EnumMember(Value = "article")]
		Article,

		[EnumMember(Value = "topic")]
		Topic
	}
}
