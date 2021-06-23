using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class UpdateRoleRequest
	{
		[JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "external_id")]
		public string ExternalId { get; set; }

		[JsonProperty(PropertyName = "banned")]
		public bool? IsBanned { get; set; }

		[JsonProperty(PropertyName = "member_add")]
		public List<int> AddedMembers { get; set; } = new List<int>();

		[JsonProperty(PropertyName = "member_remove")]
		public List<int> RemovedMembers { get; set; } = new List<int>();
	}
}
