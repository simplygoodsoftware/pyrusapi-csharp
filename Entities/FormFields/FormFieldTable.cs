using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormFieldTable : FormField
	{
		[JsonProperty("value")]
		public List<TableRow> Value { get; set; } = new List<TableRow>();

		public override string ToString()
		{
			return $"Name: {Name}, RowCount: {Value?.Count ?? 0}";
		}
	}

	public class TableRow
	{
		public TableRow(){ }

		public TableRow(int rowId, IEnumerable<FormField> cells)
		{
			RowId = rowId;
			Cells = cells?.ToList() ?? new List<FormField>();
		}

		[JsonProperty("row_id")]
		public int RowId { get; set; }

		[JsonProperty("cells")]
		public List<FormField> Cells { get; set; }

		[JsonProperty("delete", DefaultValueHandling = DefaultValueHandling.Ignore)]
		internal bool Delete { get; set; }
	}

}
