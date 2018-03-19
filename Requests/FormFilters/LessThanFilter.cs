namespace PyrusApiClient
{
	public class LessThanFilter : FormFilter
	{
		public LessThanFilter(int fieldId, object value)
			: base(OperatorId.LessThan, value)
		{
			FieldId = fieldId;
		}

		public LessThanFilter(string fieldName, object value, FormResponse form)
			: base(OperatorId.LessThan, value)
		{
			FieldId = GetFieldIdByName(fieldName, form);
		}

		public LessThanFilter(string fieldName, object value)
			:base(OperatorId.LessThan, value)
		{
			FieldName = fieldName;
		}
	}
}
