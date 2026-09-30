using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pyrus.ApiClient.JsonConverters
{
	internal class DateTimeJsonConverter : IsoDateTimeConverter
	{
		private readonly bool _useUtc;

		public DateTimeJsonConverter(string format)
		{
			DateTimeFormat = format;
		}

		public DateTimeJsonConverter(string format, bool useUtc) : this(format)
		{
			_useUtc = useUtc;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (_useUtc && value is DateTime date)
				value = date.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(date, DateTimeKind.Utc) : date.ToUniversalTime();
			base.WriteJson(writer, value, serializer);
		}
	}
}
