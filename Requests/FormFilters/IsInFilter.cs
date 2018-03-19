using System.Collections.Generic;
using System.Linq;

namespace PyrusApiClient
{
	public class IsInFilter : FormFilter
	{
		public IsInFilter(int fieldId, IEnumerable<object> values)
			: base(OperatorId.IsIn, values.ToArray())
		{
			FieldId = fieldId;
		}

		public IsInFilter(string fieldName, IEnumerable<object> values, FormResponse form)
			: base(OperatorId.IsIn, values.ToArray())
		{
			FieldId = GetFieldIdByName(fieldName, form);
		}

		public IsInFilter(string fieldName, IEnumerable<object> values)
			:base(OperatorId.IsIn, values.ToArray())
		{
			FieldName = fieldName;
		}
	}
}
