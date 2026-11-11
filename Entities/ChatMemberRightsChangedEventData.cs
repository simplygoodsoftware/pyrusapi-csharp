using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class ChatMemberRightsChangedEventData
    {
        [JsonProperty("member")]
        public ChatMemberRef Member { get; set; }

        [JsonProperty("old_rights")]
        public string OldRights { get; set; }

        [JsonProperty("new_rights")]
        public string NewRights { get; set; }

        [JsonProperty("old_permissions")]
        public string[] OldPermissions { get; set; }

        [JsonProperty("new_permissions")]
        public string[] NewPermissions { get; set; }
    }
}
