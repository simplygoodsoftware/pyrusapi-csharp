using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class ContactsResponse : ResponseBase
	{
		[JsonProperty("organizations")]
		public Organization[] Organizations { get; set; }
	}
}
