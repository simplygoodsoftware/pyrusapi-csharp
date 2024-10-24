using Newtonsoft.Json;

namespace Pyrus.ApiClient.Requests
{
    public class DeleteRoleRequest
    {
        public DeleteRoleRequest()
        {

        }

        public DeleteRoleRequest(int roleId, int taskReceiverId)
        {
            Id = roleId;
            TaskReceiverId = taskReceiverId;
        }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "task_receiver_id")]
        public int TaskReceiverId { get; set; }
    }
}
