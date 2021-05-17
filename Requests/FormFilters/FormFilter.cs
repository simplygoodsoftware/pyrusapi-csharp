using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using PyrusApiClient.Extensions;

namespace PyrusApiClient
{
	public abstract class FormFilter
	{
		protected FormFilter(OperatorId operatorId, params object[] values)
		{
			OperatorId = operatorId;
			Values = values.Select(ConvertToString).ToArray();
		}

		private static string ConvertToString(object arg)
		{
			switch (arg)
			{
				case DateTime dateTime:
					return dateTime.ToString("yyyy-MM-dd");
				case decimal dec:
					return dec.ToString(CultureInfo.InvariantCulture);
				case Checkmark _:
				case Flag _:
					return arg.GetAttribute<EnumMemberAttribute>().Value;
			}

			return arg.ToString();
		}

		internal int? FormId { get; set; }

		internal string FieldName { get; set; }

		[JsonProperty("field_id")]
		internal int? FieldId { get; set; }

		[JsonProperty("operator_id")]
		internal OperatorId OperatorId { get; }

		[JsonProperty("values")]
		internal string[] Values { get; }

		internal static int GetFieldIdByName(string fieldName, FormResponse form)
		{
			if (string.IsNullOrEmpty(fieldName))
				throw new ArgumentException("Field name can not be empty");

			List<int> fields = null;

			if (form.Fields != null)
			{
				fields = form.Fields.Where(f => !string.IsNullOrEmpty(f.Name) && f.Name.ToUpper().Equals(fieldName.ToUpper()) && f.Id.HasValue).Select(f => f.Id.Value).ToList();

				if (fields.Count > 1)
					throw new ArgumentException("Field name is not unique on the form.");

				if (fields.Count == 0)
					fields = ValidateFlatFieldsCount(fieldName, form);
			}
			else
				fields = ValidateFlatFieldsCount(fieldName, form);

			return fields.First();
		}

		private static List<int> ValidateFlatFieldsCount(string fieldName, FormResponse form)
        {
			if(form.FlatFields == null)
				throw new ArgumentException($"There is no fields on the form {form.Id}");

			var fields = form.FlatFields.Where(f => !string.IsNullOrEmpty(f.Name) && f.Name.ToUpper().Equals(fieldName.ToUpper()) && f.Id.HasValue).Select(f => f.Id.Value).ToList();

			if (fields.Count > 1)
				throw new ArgumentException("Field name is not unique on the form.");

			if (fields.Count == 0)
				throw new ArgumentException("Field with specified name not found on the form.");
			return fields;
		}

	}
}
