using Newtonsoft.Json;
using PyrusApiClient;

namespace Pyrus.ApiClient.Responses
{
	public class PermissionsResponse : ResponseBase
	{
		[JsonProperty("manager_ids")]
		public int[] Managers { get; set; }

		[JsonProperty("member_ids")]
		public int[] Members { get; set; }
	}
}
