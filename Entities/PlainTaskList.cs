using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class PlainTaskList
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("parent_id")]
		public int? ParentId { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("color")]
		public string Color { get; set; }

		[JsonProperty("is_private")]
		public bool IsPrivate { get; set; }

		[JsonProperty("supervisors")]
		public int[] SupervisorIds { get; set; }

		[JsonProperty("members")]
		public int[] MemberIds { get; set; }

		[JsonProperty("external_version")]
		public long? ExternalVersion { get; set; }

		[JsonProperty("external_id")]
		public int? ExternalId { get; set; }
	}
}