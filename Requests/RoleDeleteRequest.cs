using Newtonsoft.Json;

namespace Pyrus.ApiClient.Requests
{
	public class RoleDeleteRequest
	{
		[JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[JsonProperty(PropertyName = "task_receiver_id")]
		public int TaskReceiverId { get; set; }
	}
}
