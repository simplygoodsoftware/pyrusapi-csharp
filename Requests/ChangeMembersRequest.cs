using PyrusApiClient;
using System.Collections.Generic;

namespace Pyrus.ApiClient.Requests
{
    public class ChangeMembersRequest
    {
        public IEnumerable<Person> AddMembers { get; set; }
        public IEnumerable<Person> ChangeMembers { get; set; }
        public IEnumerable<Person> BanMembers { get; set; }
    }
}
