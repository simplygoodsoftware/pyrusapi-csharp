using System.Runtime.Serialization;
using Newtonsoft.Json;
using PyrusApiClient.Extensions;

namespace PyrusApiClient
{
	public class FormFieldStatus : FormField
	{
		[JsonProperty("value")]
		public Status? Value { get; set; }

		public override string ToString()
		{
			return $"{Value?.GetAttribute<EnumMemberAttribute>().Value}";
		}
	}
}
