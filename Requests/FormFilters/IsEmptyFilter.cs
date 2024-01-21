namespace PyrusApiClient
{
	public class IsEmptyFilter : FormFilter
	{
		public IsEmptyFilter(int fieldId)
			: base(OperatorId.IsEmpty)
		{
			FieldId = fieldId;
		}

		public IsEmptyFilter(string fieldName, FormResponse form)
			: base(OperatorId.IsEmpty)
		{
			FieldId = GetFieldIdByName(fieldName, form);
		}

		public IsEmptyFilter(string fieldName)
			:base(OperatorId.IsEmpty)
		{
			FieldName = fieldName;
		}
	}
}
