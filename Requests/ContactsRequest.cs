using Newtonsoft.Json;

namespace Pyrus.ApiClient.Requests
{
	public class ContactsRequest
	{
		[JsonProperty(PropertyName = "withinactive")] 
		public bool WithInactive { get; set; }

	}
}