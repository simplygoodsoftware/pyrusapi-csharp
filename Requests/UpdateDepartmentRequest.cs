using Newtonsoft.Json;

namespace Pyrus.ApiClient.Requests
{
	public class UpdateDepartmentRequest
	{
		[JsonProperty("id")]
		public long Id { get; set; }

		[JsonProperty("remove_manager")]
		public bool RemoveManager { get; set; }

		[JsonProperty("parent_id")]
		public long? ParentId { get; set; }

		[JsonProperty("manager_id")]
		public int? ManagerId { get; set; }

		[JsonProperty("department_name")]
		public string DepartmentName { get; set; }

		[JsonProperty("external_id")]
		public long? ExternalId { get; set; }
	}
}
