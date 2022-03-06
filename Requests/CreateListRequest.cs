using Newtonsoft.Json;

namespace Pyrus.ApiClient.Requests
{
	public class CreateListRequest
	{
		[JsonProperty("parent_id")]
		public int? ParentId { get; set; }

		[JsonProperty("name")]
		public string ListName { get; set; }

		[JsonProperty("color")]
		public string Color { get; set; }

		[JsonProperty("is_private")]
		public bool? IsPrivate { get; set; }

		[JsonProperty("added_supervisors")]
		public int[] AddedSupervisorIds { get; set; }

		[JsonProperty("removed_supervisors")]
		public int[] RemovedSupervisorIds { get; set; }

		[JsonProperty("added_members")]
		public int[] AddedMemberIds { get; set; }

		[JsonProperty("removed_members")]
		public int[] RemovedMemberIds { get; set; }

		[JsonProperty("external_version")]
		public long? ExternalVersion { get; set; }

		[JsonProperty("external_id")]
		public int? ExternalId { get; set; }
	}
}
