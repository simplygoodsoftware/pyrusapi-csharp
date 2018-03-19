using System;
using System.Globalization;
using System.Runtime.Serialization;
using PyrusApiClient.Extensions;

namespace PyrusApiClient
{
	public class FilterValue
	{
		internal string Value;

		public FilterValue(DateTime value)
		{
			Value = value.ToString("yyyy-MM-dd");
		}

		public FilterValue(string value)
		{
			Value = value;
		}

		public FilterValue(int value)
		{
			Value = value.ToString();
		}

		public FilterValue(long value)
		{
			Value = value.ToString();
		}

		public FilterValue(decimal value)
		{
			Value = value.ToString(CultureInfo.InvariantCulture);
		}

		public FilterValue(Person value)
		{
			Value = value.Id.ToString();
		}

		public FilterValue(Catalog value)
		{
			Value = value.ItemId.ToString();
		}

		public FilterValue(Checkmark value)
		{
			Value = value.GetAttribute<EnumMemberAttribute>().Value;
		}

		public FilterValue(Flag value)
		{
			Value = value.GetAttribute<EnumMemberAttribute>().Value;
		}

		public override string ToString()
		{
			return Value;
		}
	}
}
