using System;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	public class FormFieldDate : FormField
	{
		[JsonConverter(typeof(DateTimeJsonConverter), Constants.DateFormat)]
		[JsonProperty("value")]
		public DateTime? Value { get; set; }

		public override string ToString()
		{
			return $"{Value?.ToString(Constants.DateTimeFormat)}";
		}
	}
}
