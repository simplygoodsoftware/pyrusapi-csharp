using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PyrusApiClient;

namespace Pyrus.ApiClient.JsonConverters
{
    internal sealed class ChatSystemEventJsonConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType) => objectType == typeof(ChatSystemEvent);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var value = JObject.Load(reader);
            var type = (string)value["type"];
            Type dataType;
            switch (type)
            {
                case "group_created":
                    dataType = typeof(ChatGroupCreatedEventData);
                    break;
                case "members_added":
                case "members_removed":
                    dataType = typeof(ChatMembersChangedEventData);
                    break;
                case "member_rights_changed":
                    dataType = typeof(ChatMemberRightsChangedEventData);
                    break;
                case "group_info_changed":
                    dataType = typeof(ChatGroupInfoChangedEventData);
                    break;
                case "message_pinned":
                case "message_unpinned":
                    dataType = typeof(ChatMessagePinnedEventData);
                    break;
                case "group_avatar_changed":
                    dataType = typeof(ChatGroupAvatarChangedEventData);
                    break;
                case "joined_via_invite":
                    dataType = typeof(ChatJoinedViaInviteEventData);
                    break;
                default:
                    dataType = typeof(ChatSystemEventData);
                    break;
            }
            return new ChatSystemEvent
            {
                Type = type,
                Data = value["data"] is JObject data ? (ChatSystemEventData)data.ToObject(dataType, serializer) : null,
                AdditionalData = value.Properties().Where(x => x.Name != "type" && x.Name != "data").ToDictionary(x => x.Name, x => x.Value)
            };
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotSupportedException();
    }
}
