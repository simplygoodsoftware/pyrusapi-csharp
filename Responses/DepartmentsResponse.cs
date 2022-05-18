using Newtonsoft.Json;
using PyrusApiClient;

namespace Pyrus.ApiClient.Responses
{
	public class DepartmentsResponse : ResponseBase
	{
		[JsonProperty(PropertyName = "departments")]
		public Department[] Departments { get; set; }
	}
}
