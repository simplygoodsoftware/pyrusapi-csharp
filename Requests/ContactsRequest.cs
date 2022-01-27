using Newtonsoft.Json;

namespace Pyrus.ApiClient.Requests
{
	public class ContactsRequest
	{
		[JsonProperty(PropertyName = "include_inactive")] 
		public bool IncludeInactive { get; set; }

	}
}