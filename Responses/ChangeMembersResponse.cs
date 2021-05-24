using PyrusApiClient;
using System.Collections.Generic;

namespace Pyrus.ApiClient.Responses
{
    public class ChangeMembersResponse : ResponseBase
    {
        public IEnumerable<Person> Members { get; set; } = new List<Person>();
        public IEnumerable<string> Errors { get; set; } = new List<string>();
    }
}
