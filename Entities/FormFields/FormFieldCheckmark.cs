using System.Runtime.Serialization;
using Newtonsoft.Json;
using PyrusApiClient.Extensions;

namespace PyrusApiClient
{
	public class FormFieldCheckmark : FormField
	{
		[JsonProperty("value")]
		public Checkmark? Value { get; set; }

		public override string ToString()
		{
			return $"{Value?.GetAttribute<EnumMemberAttribute>()?.Value}";
		}
	}
}
