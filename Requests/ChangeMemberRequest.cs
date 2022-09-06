using Newtonsoft.Json;
using PyrusApiClient;

namespace Pyrus.ApiClient.Requests
{
	public class ChangeMemberRequest : UpdateMemberRequest
	{
		[JsonProperty(PropertyName = "id")]
		public int Id { get; set; }
	}
}
