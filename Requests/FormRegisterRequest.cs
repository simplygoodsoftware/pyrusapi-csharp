using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using PyrusApiClient.Extensions;

namespace PyrusApiClient
{
	public class FormRegisterRequest
	{
		[JsonProperty("steps")]
		public int[] Steps { get; set; }

		[JsonProperty("include_archived")]
		public bool? IncludeArchived { get; set; }

		[JsonProperty("filters")]
		public List<FormFilter> Filters { get; set; }
	}

	public abstract class FormFilter
	{
		[JsonProperty("field_id")]
		internal int FieldId { get; set; }

		[JsonProperty("operator_id")]
		internal OperatorId OperatorId { get; set; }

		[JsonProperty("values")]
		internal FilterValue[] Values { get; set; }
	}

	public class EqualsFilter : FormFilter
	{
		public EqualsFilter(int fieldId, FilterValue value)
		{
			FieldId = fieldId;
			OperatorId = OperatorId.Equals;
			Values =  new [] { value };
		}
	}

	public class GreaterThanFilter : FormFilter
	{
		public GreaterThanFilter(int fieldId, FilterValue value)
		{
			FieldId = fieldId;
			OperatorId = OperatorId.GreaterThan;
			Values = new[] { value };
		}
	}

	public class LessThanFilter : FormFilter
	{
		public LessThanFilter(int fieldId, FilterValue value)
		{
			FieldId = fieldId;
			OperatorId = OperatorId.LessThan;
			Values = new[] { value };
		}
	}

	public class RangeFilter : FormFilter
	{
		public RangeFilter(int fieldId, FilterValue fromValue, FilterValue toValue)
		{
			FieldId = fieldId;
			OperatorId = OperatorId.Range;
			Values = new[] { fromValue, toValue };
		}
	}

	public class IsInFilter : FormFilter
	{
		public IsInFilter(int fieldId, FilterValue[] values)
		{
			FieldId = fieldId;
			OperatorId = OperatorId.IsIn;
			Values = values;
		}
	}

	public enum OperatorId
	{
		Equals = 1,
		LessThan = 2,
		GreaterThan = 3,
		IsIn = 4,
		Range = 5,
		MatchPrefix = 6
	}

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
	}
}
