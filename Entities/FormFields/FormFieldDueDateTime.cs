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

		public FormFieldDueDateTime(int id, DateTime? value, int? duration = null)
		{
			Value = value;
			Id = id;
			Duration = duration;
		}

		[JsonConverter(typeof(DateTimeJsonConverter), Constants.DateTimeFormat)]
		[JsonProperty("value")]
		public DateTime? Value { get; set; }

        [JsonProperty("duration")]
        public int? Duration { get; set; }

        public override string ToString()
		{
            return Value.HasValue && Duration.HasValue
                ? $"{Value.Value.ToString(Constants.DateTimeFormat)} - {Value.Value.AddMinutes(Duration.Value).ToString(Constants.DateTimeFormat)}"
                : $"{Value?.ToString(Constants.DateTimeFormat)}";
        }
    }
}
