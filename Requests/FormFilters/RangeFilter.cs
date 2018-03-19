using System;

namespace PyrusApiClient
{
	public class RangeFilter : FormFilter
	{
		public RangeFilter(int fieldId, object fromValue, object toValue)
			: base(OperatorId.Range, fromValue, toValue)
		{
			FieldId = fieldId;
		}

		public RangeFilter(string fieldName, object fromValue, object toValue, FormResponse form)
			: this(GetFieldIdByName(fieldName, form), fromValue, toValue)
		{
		}

		public RangeFilter(string fieldName, object fromValue, object toValue)
			:base(OperatorId.Range, fromValue, toValue)
		{
			FieldName = fieldName;
		}
	}
}
