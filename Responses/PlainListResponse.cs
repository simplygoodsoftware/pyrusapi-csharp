using Newtonsoft.Json;
using PyrusApiClient;

namespace Pyrus.ApiClient.Responses
{
	public class PlainListResponse : ResponseBase
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("parent_id")]
		public int? ParentId { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("color")]
		public string Color { get; set; }

		[JsonProperty("deleted")]
		public bool IsDeleted { get; set; }

		[JsonProperty("list_type")]
		public ListType? ListType { get; set; }

		[JsonProperty("has_form")]
		public bool HasForm { get; set; }

		[JsonProperty("manager_ids")]
		public int[] ManagerIds { get; set; }

		[JsonProperty("member_ids")]
		public int[] MemberIds { get; set; }

		[JsonProperty("version")]
		public long Version { get; set; }

		[JsonProperty("external_version")]
		public long? ExternalVersion { get; set; }

		[JsonProperty("external_id")]
		public int? ExternalId { get; set; }

		public PlainTaskList PlainTaskList =>
			new PlainTaskList
			{
				Id = Id,
				Name = Name,
				ParentId = ParentId,
				ListType = ListType,
				Color = Color,
				ManagerIds = ManagerIds,
				MemberIds = MemberIds,
				ExternalId = ExternalId,
				ExternalVersion = ExternalVersion
			};

	}
}
