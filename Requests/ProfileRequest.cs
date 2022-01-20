using Newtonsoft.Json;
namespace Pyrus.ApiClient.Requests
{
	public class ProfileRequest
	{
		[JsonProperty(PropertyName = "withinactive")]
		public bool WithInactive { get; set; }
	}
}
