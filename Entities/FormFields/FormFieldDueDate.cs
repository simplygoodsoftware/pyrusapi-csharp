using System;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	public class FormFieldDueDate : FormField
	{
		[JsonConverter(typeof(DateTimeJsonConverter), "yyyy-MM-dd")]
		[JsonProperty("value")]
		public DateTime? Value { get; set; }
	}
}
