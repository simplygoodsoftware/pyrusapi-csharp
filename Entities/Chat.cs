using System;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
    public class Chat : ChatSummary
    {
        [JsonProperty("created_at")]
        [JsonConverter(typeof(DateTimeJsonConverter), Constants.DateTimeFormat, true)]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("notification_mode")]
        public string NotificationMode { get; set; }

        [JsonProperty("avatar_id")]
        public int? AvatarId { get; set; }

        [JsonProperty("permissions")]
        public string[] Permissions { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("basic_permissions")]
        public string[] BasicPermissions { get; set; }

        [JsonProperty("members")]
        public ChatMember[] Members { get; set; }
    }
}
