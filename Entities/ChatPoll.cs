using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PyrusApiClient
{
    public class ChatPoll
    {
        [JsonProperty("question")]
        public string Question { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("is_anonymous")]
        public bool IsAnonymous { get; set; }

        [JsonProperty("allows_multiple_answers")]
        public bool AllowsMultipleAnswers { get; set; }

        [JsonProperty("allows_vote_cancellation")]
        public bool AllowsVoteCancellation { get; set; }

        [JsonProperty("is_closed")]
        public bool IsClosed { get; set; }

        [JsonProperty("voters_count")]
        public int VotersCount { get; set; }

        [JsonProperty("has_voted")]
        public bool HasVoted { get; set; }

        [JsonProperty("selected_option_ids")]
        public int[] SelectedOptionIds { get; set; }

        [JsonProperty("options")]
        public ChatPollOption[] Options { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData { get; set; }
    }
}
