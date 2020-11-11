using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class Subscriber
    {
        [JsonProperty("person")]
        public Person Person { get; set; }

        [JsonProperty("approval_choice")]
        public ApprovalChoice? ApprovalChoice { get; set; }
    }
}
