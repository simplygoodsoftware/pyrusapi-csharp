using System;
using Newtonsoft.Json;

namespace PyrusApiClient
{
    /// <summary>
    /// Запрос на добавление информации по звонку
    /// </summary>
    public class UpdateCallRequest
    {
        /// <summary>
        /// Время, когда начался входящий звонок (временной формат в UTC, YYYY-MM-DDThh:mm:ssZ)
        /// </summary>
        [JsonProperty(PropertyName = "start_time")]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Время, когда звонок был закончен (временной формат в UTC, YYYY-MM-DDThh:mm:ssZ)
        /// </summary>
        [JsonProperty(PropertyName = "end_time")]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Оценка звонка (целое число от 1 до 5)
        /// </summary>
        [JsonProperty(PropertyName = "rating")]
        public int? Rating { get; set; }

        /// <summary>
        /// Кем был завершён разговор
        /// </summary>
        [JsonProperty(PropertyName = "disconnect_party")]
        public DisconnectParty DisconnectParty { get; set; }

        /// <summary>
        /// Статус звонка
        /// </summary>
        [JsonProperty(PropertyName = "call_status")]
        public CallStatus CallStatus { get; set; }

        /// <summary>
        /// Уникальный идентификатор файла, который был загружен с помощью функции /files/upload
        /// </summary>
        [JsonProperty(PropertyName = "file_guid")]
        public Guid? FileGuid { get; set; }
    }
}