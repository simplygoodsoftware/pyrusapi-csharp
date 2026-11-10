using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class ChatPollOption
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        [JsonProperty("voter_ids")]
        public int[] VoterIds { get; set; }
    }
}
