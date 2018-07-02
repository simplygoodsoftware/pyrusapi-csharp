using System.Runtime.Serialization;
using Newtonsoft.Json;
using PyrusApiClient.Extensions;

namespace PyrusApiClient
{
	public class FormFieldFlag : FormField
	{
		[JsonProperty("value")]
		public Flag? Value { get; set; }

		public override string ToString()
		{
			return $"{Value?.GetAttribute<EnumMemberAttribute>().Value}";
		}
	}
}
