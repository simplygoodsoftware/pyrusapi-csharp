namespace Pyrus.ApiClient.Requests.Builders
{
    public class DeleteRoleRequestBuilder
    {
        private readonly DeleteRoleRequest _request;

        public int RoleId { get; }
        public int TaskReceiverId { get; }

        public DeleteRoleRequestBuilder(int roleId, int taskReceiverId)
        {
            RoleId = roleId;
            TaskReceiverId = taskReceiverId;
            _request = new DeleteRoleRequest(roleId, taskReceiverId);
        }

        public static implicit operator DeleteRoleRequest(DeleteRoleRequestBuilder drrb)
        {
            return drrb._request;
        }
    }
}