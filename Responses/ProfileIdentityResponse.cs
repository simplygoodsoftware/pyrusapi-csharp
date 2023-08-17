using Newtonsoft.Json;
using PyrusApiClient;

namespace Pyrus.ApiClient.Responses
{
	public class ProfileIdentityResponse : ResponseBase
	{
		[JsonProperty("email")]
		public string Email { get; internal set; }

		[JsonProperty("organization_id")]
		public int OrganizationId { get; internal set; }
	}
}