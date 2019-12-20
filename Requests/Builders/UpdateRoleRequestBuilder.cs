using System.Collections.Generic;
using PyrusApiClient;

namespace Pyrus.ApiClient.Requests.Builders
{
    public class UpdateRoleRequestBuilder
    {
        public int RoleId { get; }
        private readonly UpdateRoleRequest _request;

        public UpdateRoleRequestBuilder(int roleId)
        {
            RoleId = roleId;
            _request = new UpdateRoleRequest();
        }

        public UpdateRoleRequestBuilder SetName(string name)
        {
            _request.Name = name;
            return this;
        }

        public UpdateRoleRequestBuilder SetExternalId(string externalId)
        {
            _request.ExternalId = externalId;
            return this;
        }

        public UpdateRoleRequestBuilder AddMember(int personId)
        {
            _request.RemovedMembers.Remove(personId);
            _request.AddedMembers.Add(personId);
            return this;
        }

        public UpdateRoleRequestBuilder AddMembers(IEnumerable<int> personIds)
        {
            foreach (var personId in personIds)
            {
                _request.RemovedMembers.Remove(personId);
                _request.AddedMembers.Add(personId);
            }
            return this;
        }

        public UpdateRoleRequestBuilder AddMembers(params int[] personIds)
        {
            foreach (var personId in personIds)
            {
                _request.RemovedMembers.Remove(personId);
                _request.AddedMembers.Add(personId);
            }
            return this;
        }

        public UpdateRoleRequestBuilder RemoveMember(int personId)
        {
            _request.AddedMembers.Remove(personId);
            _request.RemovedMembers.Add(personId);
            return this;
        }

        public UpdateRoleRequestBuilder RemoveMembers(IEnumerable<int> personIds)
        {
            foreach (var personId in personIds)
            {
                _request.AddedMembers.Remove(personId);
                _request.RemovedMembers.Add(personId);
            }
            return this;
        }

        public UpdateRoleRequestBuilder RemoveMembers(params int[] personIds)
        {
            foreach (var personId in personIds)
            {
                _request.AddedMembers.Remove(personId);
                _request.RemovedMembers.Add(personId);
            }
            return this;
        }

        public UpdateRoleRequestBuilder Ban()
        {
            _request.IsBanned = true;
            return this;
        }

        public UpdateRoleRequestBuilder UnBan()
        {
            _request.IsBanned = false;
            return this;
        }

        public static implicit operator UpdateRoleRequest(UpdateRoleRequestBuilder crrb)
        {
            return crrb._request;
        }
    }
}