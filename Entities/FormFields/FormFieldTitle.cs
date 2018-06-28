using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using PyrusApiClient.Extensions;

namespace PyrusApiClient
{
	public class FormFieldTitle : FormField
	{
		[JsonProperty("value")]
		public Title Value { get; set; } = new Title();

		public override string ToString()
		{
			return $"{Value?.GetAttribute<EnumMemberAttribute>().Value}";
		}
	}

	public class Title
	{
		[JsonProperty("checkmark")]
		public Checkmark? Checkmark { get; set; }

		[JsonProperty("fields")]
		public List<FormField> Fields { get; set; } = new List<FormField>();
	}
}
