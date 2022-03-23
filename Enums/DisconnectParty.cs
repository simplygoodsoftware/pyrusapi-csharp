using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PyrusApiClient
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DisconnectParty
    {
        [EnumMember(Value = "agent")] 
        Agent,

        [EnumMember(Value = "client")] 
        Client,

        [EnumMember(Value = "error")] 
        Error,

        [EnumMember(Value = "other")] 
        Other
    }
}