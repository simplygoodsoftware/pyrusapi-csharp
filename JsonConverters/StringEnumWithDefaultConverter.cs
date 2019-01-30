using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class StringEnumWithDefaultConverter : StringEnumConverter
{
	private readonly int _defaultValue;

	public StringEnumWithDefaultConverter()
	{ }

	public StringEnumWithDefaultConverter(int defaultValue)
	{
		_defaultValue = defaultValue;
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		try
		{
			return base.ReadJson(reader, objectType, existingValue, serializer);
		}
		catch
		{
			return Enum.Parse(objectType, $"{_defaultValue}");
		}
	}

	public override bool CanConvert(Type objectType)
	{
		return base.CanConvert(objectType) && objectType.GetTypeInfo().IsEnum && Enum.IsDefined(objectType, _defaultValue);
	}
}