using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class ChatVoteRequest
    {
        [JsonProperty("option_ids", DefaultValueHandling = DefaultValueHandling.Include)]
        public int[] OptionIds { get; set; }
    }
}
