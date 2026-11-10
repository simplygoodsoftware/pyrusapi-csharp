using Newtonsoft.Json.Converters;

namespace Pyrus.ApiClient.JsonConverters
{
	internal class DateTimeJsonConverter : IsoDateTimeConverter
	{
		public DateTimeJsonConverter(string format)
		{
			DateTimeFormat = format;
		}
	}
}
