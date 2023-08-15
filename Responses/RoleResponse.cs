using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class RoleResponse : ResponseBase
	{
		[JsonProperty("id")]
		public int? Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("external_id")]
		public string ExternalId { get; set; }

		[JsonProperty("avatar_id")]
		public int? AvatarId { get; set; }

		[JsonProperty("external_avatar_id")]
		public int? ExternalAvatarId { get; set; }

		[JsonProperty("banned")]
		public bool Banned { get; set; }

		[JsonProperty("fired")]
		public bool Fired { get; set; }

		[JsonProperty("member_ids")]
		public List<int> MemberIds { get; set; } = new List<int>();

		public Role Role =>
			new Role
			{
				Id = Id,
				Name = Name,
				ExternalId = ExternalId,
				AvatarId = AvatarId,
				ExternalAvatarId = ExternalAvatarId,
				Banned = Banned,
				MemberIds = MemberIds
			};
	}
}
