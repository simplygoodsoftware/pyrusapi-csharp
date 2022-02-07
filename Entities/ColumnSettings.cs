using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class ColumnSettings
	{
		[JsonProperty("original_pos")]
		public int ColumnOriginalPos { get; set; }

		[JsonProperty("sort_order")]
		public int? SortOrder { get; set; }

		[JsonProperty("visible")]
		public bool Visible { get; set; }

		[JsonProperty("group_by")]
		public bool GroupBy { get; set; }
	}
}
