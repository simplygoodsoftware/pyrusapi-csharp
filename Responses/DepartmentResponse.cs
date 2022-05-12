using Newtonsoft.Json;
using PyrusApiClient;

namespace Pyrus.ApiClient.Responses
{
	public class DepartmentResponse : ResponseBase
	{
		[JsonProperty("id")]
		public int? Id { get; set; }

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
