using Newtonsoft.Json;

namespace PyrusApiClient
{
    /// <summary>
    /// Запрос на регистрацию события по звонку
    /// </summary>
    public class CallEventRequest
    {
        /// <summary>
        /// Внутренний номер оператора
        /// </summary>
        [JsonProperty(PropertyName = "extension")]
        public string Extension { get; set; }

        /// <summary>
        /// Событие, которое регистрируется в системе
        /// </summary>
        [JsonProperty(PropertyName = "event_type")]
        public CallEventType EventType { get; set; }
    }
}