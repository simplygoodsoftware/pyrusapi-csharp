using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormFieldTable : FormField
	{
		[JsonProperty("value")]
		public TableRow[] Value { get; set; }
	}

	public class TableRow
	{
		[JsonProperty("row_id")]
		public int RowId { get; set; }

		[JsonProperty("cells")]
		public FormField[] Cells { get; set; }
	}

}
