using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class CreateChatPoll
    {
        [JsonProperty("question")]
        public string Question { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("options", DefaultValueHandling = DefaultValueHandling.Include)]
        public string[] Options { get; set; }

        [JsonProperty("is_anonymous")]
        public bool? IsAnonymous { get; set; }

        [JsonProperty("allows_multiple_answers")]
        public bool? AllowsMultipleAnswers { get; set; }

        [JsonProperty("allows_vote_cancellation")]
        public bool? AllowsVoteCancellation { get; set; }
    }
}
