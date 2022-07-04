using Newtonsoft.Json;

namespace Pyrus.ApiClient.Requests
{
	public class DeleteBotRequest
	{
		[JsonProperty(PropertyName = "task_receiver_id")]
		public int TaskReceiverId { get; set; }
	}
}
