using System;
using Newtonsoft.Json;

namespace PyrusApiClient
{
    /// <summary>
    /// Результат выполнения запроса на регистрацию звонка
    /// </summary>
    public class CreateCallResponse : ResponseBase
    {
        /// <summary>
        /// id задачи, которая была создана при вызове функции
        /// или к которой информация об осуществлённом звонке добавилась в виде комментария
        /// </summary>
        [JsonProperty(PropertyName = "task_id")]
        public int TaskId { get; set; }

        /// <summary>
        /// GUID звонка, который регистрируется за новым входящим звонком для того,
        /// чтобы к звонку можно было добавлять дополнительную информацию
        /// </summary>
        [JsonProperty(PropertyName = "call_guid")]
        public Guid CallGuid { get; set; }
    }
}