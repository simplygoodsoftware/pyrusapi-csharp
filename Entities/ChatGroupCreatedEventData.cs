using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class ChatGroupCreatedEventData : ChatSystemEventData
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("members")]
        public ChatMemberRef[] Members { get; set; }
    }
}
