using Newtonsoft.Json;

namespace Pyrus.ApiClient.Requests
{
	public class DeleteDepartmentRequest
	{
		[JsonProperty("id")]
		public long Id { get; set; }
	}
}
