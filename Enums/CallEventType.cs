using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PyrusApiClient
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CallEventType
    {
        [EnumMember(Value = "show")] 
        Show
    }
}