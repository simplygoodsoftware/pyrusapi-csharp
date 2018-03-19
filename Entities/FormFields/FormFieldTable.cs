using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormFieldTable : FormField
	{
		[JsonProperty("value")]
		public List<TableRow> Value { get; set; } = new List<TableRow>();
	}

	public class TableRow
	{
		public TableRow(){ }

		public TableRow(int rowId, IEnumerable<FormField> cells)
		{
			RowId = rowId;
			Cells = cells.ToList();
		}

		[JsonProperty("row_id")]
		public int RowId { get; set; }

		[JsonProperty("cells")]
		public List<FormField> Cells { get; set; }
	}

}
