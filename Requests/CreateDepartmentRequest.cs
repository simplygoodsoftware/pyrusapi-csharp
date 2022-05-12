using Newtonsoft.Json;

namespace Pyrus.ApiClient.Requests
{
	public class CreateDepartmentRequest
	{
		[JsonProperty("parent_id")]
		public long? ParentId { get; set; }

		[JsonProperty("head_of_department")]
		public int? HeadOfDepartment { get; set; }

		[JsonProperty("department_name")]
		public string DepartmentName { get; set; }

		[JsonProperty("external_id")]
		public long? ExternalId { get; set; }
	}
}
