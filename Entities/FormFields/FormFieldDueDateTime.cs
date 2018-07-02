using System;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	public class FormFieldDueDateTime : FormField
	{
		public FormFieldDueDateTime()
		{
		}

		public FormFieldDueDateTime(int id, DateTime? value)
		{
			Value = value;
			Id = id;
		}

		[JsonConverter(typeof(DateTimeJsonConverter), Constants.DateTimeFormat)]
		[JsonProperty("value")]
		public DateTime? Value { get; set; }

		public override string ToString()
		{
			return $"{Value?.ToString(Constants.DateTimeFormat)}";
		}
	}
}
