using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class ChatGroupCreatedEventData : ChatSystemEventData
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("members")]
        public ChatMemberRef[] Members { get; set; }
    }
}
