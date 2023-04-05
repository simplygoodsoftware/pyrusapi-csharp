using Newtonsoft.Json;
using PyrusApiClient;

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

		[JsonProperty("list_type")]
		public ListType? ListType { get; set; }

		[JsonProperty("added_managers")]
		public int[] AddedManagerIds { get; set; }

		[JsonProperty("added_members")]
		public int[] AddedMemberIds { get; set; }

		[JsonProperty("external_version")]
		public long? ExternalVersion { get; set; }

		[JsonProperty("external_id")]
		public int? ExternalId { get; set; }

		[JsonProperty("is_private")]
		public bool? IsPrivate { get; set; }
	}
}
