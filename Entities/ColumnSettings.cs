using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class ColumnSettings
	{
		[JsonProperty("original_position")]
		public int ColumnOriginalPosition { get; set; }

		[JsonProperty("sort_order")]
		public int? SortOrder { get; set; }

		[JsonProperty("visible")]
		public bool Visible { get; set; }

		[JsonProperty("group_by")]
		public bool GroupBy { get; set; }
	}
}
