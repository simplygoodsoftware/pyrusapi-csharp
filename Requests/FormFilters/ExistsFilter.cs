namespace PyrusApiClient
{
	public class ExistsFilter : FormFilter
	{
		public ExistsFilter(int fieldId)
			: base(OperatorId.Exists)
		{
			FieldId = fieldId;
		}

		public ExistsFilter(string fieldName, FormResponse form)
			: base(OperatorId.Exists)
		{
			FieldId = GetFieldIdByName(fieldName, form);
		}

		public ExistsFilter(string fieldName)
			:base(OperatorId.Exists)
		{
			FieldName = fieldName;
		}
	}
}
