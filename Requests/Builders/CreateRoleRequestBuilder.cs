using System.Collections.Generic;
using PyrusApiClient;

namespace Pyrus.ApiClient.Requests.Builders
{
    public class CreateRoleRequestBuilder
    {
        private readonly CreateRoleRequest _request;

        public CreateRoleRequestBuilder(string name)
        {
            _request = new CreateRoleRequest
            {
                Name = name
            };
        }

        public CreateRoleRequestBuilder WithExternalId(string externalId)
        {
            _request.ExternalId = externalId;
            return this;
        }

        public CreateRoleRequestBuilder AddMember(int personId)
        {
            _request.Members.Add(personId);
            return this;
        }

        public CreateRoleRequestBuilder AddMembers(IEnumerable<int> personIds)
        {
            _request.Members.AddRange(personIds);
            return this;
        }

        public CreateRoleRequestBuilder AddMembers(params int[] personIds)
        {
            _request.Members.AddRange(personIds);
            return this;
        }

        public static implicit operator CreateRoleRequest(CreateRoleRequestBuilder crrb)
        {
            return crrb._request;
        }
    }
}
