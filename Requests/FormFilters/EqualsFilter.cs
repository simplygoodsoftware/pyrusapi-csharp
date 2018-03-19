namespace PyrusApiClient
{
	public class EqualsFilter : FormFilter
	{
		public EqualsFilter(int fieldId, object value)
			:base(OperatorId.Equals, value)
		{
			FieldId = fieldId;
		}

		public EqualsFilter(string fieldName, object value, FormResponse form)
			: this(GetFieldIdByName(fieldName, form), value)
		{
			FieldId = GetFieldIdByName(fieldName, form);
		}

		public EqualsFilter(string fieldName, object value)
			: base(OperatorId.Equals, value)
		{
			FieldName = fieldName;
		}
	}
}
