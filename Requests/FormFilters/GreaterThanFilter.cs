namespace PyrusApiClient
{
	public class GreaterThanFilter : FormFilter
	{
		public GreaterThanFilter(int fieldId, object value)
			: base(OperatorId.GreaterThan, value)
		{
			FieldId = fieldId;
		}

		public GreaterThanFilter(string fieldName, object value, FormResponse form)
			:this(GetFieldIdByName(fieldName, form), value)
		{
		}

		public GreaterThanFilter(string fieldName, object value)
			: base(OperatorId.GreaterThan, value)
		{
			FieldName = fieldName;
		}
	}
}
