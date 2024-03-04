using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class AuthResponse : ResponseBase
	{
		[JsonProperty("access_token")]
		public string AccessToken { get; set; }

        [JsonProperty("api_url")]
        public string ApiUrl { get; set; }

        [JsonProperty("files_url")]
        public string FilesUrl { get; set; }

        public bool Success => AccessToken != null;
	}
}
