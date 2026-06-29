using Newtonsoft.Json;
using PyrusApiClient;

namespace Pyrus.ApiClient.Responses
{
	public class DeleteMeetingResponse : ResponseBase
	{
		[JsonProperty("deleted")]
		public bool Deleted { get; set; }
	}
}
