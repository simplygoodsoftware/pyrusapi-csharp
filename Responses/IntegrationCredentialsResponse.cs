using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class IntegrationCredentialsResponse : ResponseBase
	{
		[JsonProperty("integrationaccountid")]
		public int IntegrationAccountId { get; set; }

		[JsonProperty("credentials")]
		public string Credentials { get; set; }
	}
}