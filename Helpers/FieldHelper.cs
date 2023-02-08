using System.Collections.Generic;
using System.Linq;

namespace PyrusApiClient
{
	internal class FieldHelper
	{
		internal static List<FormField> GetFlatFieldsListByTask(List<FormField> fields)
		{
			var res = new List<FormField>();
			if (fields == null || fields.Count == 0)
				return res;

			foreach (var field in fields)
			{
				res.Add(field);

				if (field is FormFieldMultipleChoice ffmc)
					res.AddRange(GetFlatFieldsListByTask(ffmc.Value?.Fields));
				else if (field is FormFieldTitle fft)
					res.AddRange(GetFlatFieldsListByTask(fft.Value?.Fields));
				else if (field is FormFieldTable fftb)
					foreach (var row in fftb.Value ?? new List<TableRow>())
						if (row.Cells?.Count > 0)
							res.AddRange(row.Cells);
			}

			return res;
		}

		internal static List<FormField> GetFlatFieldsByForm(List<FormField> fields)
		{
			var res = new List<FormField>();
			if (fields == null || fields.Count == 0)
				return res;

			foreach (var field in fields)
			{
				res.Add(field);

				if (field is FormFieldMultipleChoice)
					res.AddRange(GetFlatFieldsByForm(field.Info?.Options?.Where(o => o?.Fields?.Count > 0).SelectMany(o => o.Fields).ToList()));
				else if (field is FormFieldTitle)
					res.AddRange(GetFlatFieldsByForm(field.Info?.Fields));
				else if (field is FormFieldTable)
					if (field.Info?.Columns?.Count > 0)
						res.AddRange(field.Info.Columns);
			}

			return res;
		}
	}
}
