using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class AuthResponse : ResponseBase
	{
		[JsonProperty("access_token")]
		public string AccessToken { get; set; }

		public bool Success => AccessToken != null;
	}
}
