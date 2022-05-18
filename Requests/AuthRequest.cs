using Newtonsoft.Json;

namespace Pyrus.ApiClient.Requests
{
	internal class AuthRequest
	{
		[JsonProperty(PropertyName = "login")]
		internal string Login { get; set; }

		[JsonProperty(PropertyName = "security_key")]
		internal string SecurityKey { get; set; }

		[JsonProperty(PropertyName = "person_id")]
		internal int? PersonId { get; set; }

	}
}
