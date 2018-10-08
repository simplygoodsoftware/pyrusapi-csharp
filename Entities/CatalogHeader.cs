using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class CatalogHeader
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("type")]
		public CatalogHeaderType Type { get; set; }
	}

	public enum CatalogHeaderType
	{
		[EnumMember(Value = "text")]
		Text,

		[EnumMember(Value = "workflow")]
		Workflow
	}
}
