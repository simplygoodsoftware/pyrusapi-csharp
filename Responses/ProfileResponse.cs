using Newtonsoft.Json;
using PyrusApiClient;

namespace Pyrus.ApiClient.Responses
{
	public class ProfileResponse : ResponseBase
	{
		[JsonProperty("person_id")]
		public int PersonId { get; internal set; }

		[JsonProperty("first_name")]
		public string FirstName { get; internal set; }

		[JsonProperty("last_name")]
		public string LastName { get; internal set; }

		[JsonProperty("email")]
		public string Email { get; internal set; }

		[JsonProperty("locale")]
		public string Locale { get; internal set; }

		[JsonProperty("organization_id")]
		public int OrganizationId { get; internal set; }

		[JsonProperty("organization")]
		public Organization Organization { get; internal set; }

        [JsonProperty("timezone_offset")]
        public int? TimeZoneOffset { get; internal set; }
    }
}