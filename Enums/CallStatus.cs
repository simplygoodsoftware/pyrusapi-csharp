using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PyrusApiClient
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CallStatus
    {
        [EnumMember(Value = "answered")] 
        Answered,

        [EnumMember(Value = "no answer")] 
        NoAnswer,

        [EnumMember(Value = "busy")] 
        Busy,

        [EnumMember(Value = "error")] 
        Error,

        [EnumMember(Value = "other")] 
        Other
    }
}