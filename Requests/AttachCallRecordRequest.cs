using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
    /// <summary>
    /// Запрос для добавления в задачу Pyrus информации о звонке
    /// </summary>
    public class AttachCallRecordRequest
    {
        /// <summary>
        /// Уникальный идентификатор файла, который был загружен с помощью запроса /files/upload
        /// </summary>
        [JsonProperty(PropertyName = "record_file")]
        public string RecordFile { get; set; }
        
        /// <summary>
        /// Номер телефона позвонившего
        /// </summary>
        [JsonProperty(PropertyName = "from_number")]
        public string FromNumber { get; set; }
        
        /// <summary>
        /// Номер телефона, на который был совершен звонок
        /// </summary>
        [JsonProperty(PropertyName = "to_number")]
        public string ToNumber { get; set; }
        
        /// <summary>
        /// Идентификатор звонка во внешней системе
        /// </summary>
        /// <remarks>Заполнять не обязательно</remarks>
        [JsonProperty(PropertyName = "external_id")]
        public string ExternalId { get; set; }

        /// <summary>
        /// Id созданной задачи. Возвращается в integrations/call
        /// </summary>
        [JsonProperty(PropertyName = "task_id")]
        public int TaskId { get; set; }
        
        /// <summary>
        /// Данные для автоматического заполнения полей формы
        /// </summary>
        [JsonProperty(PropertyName = "mappings")]
        public List<FormMapping> Mappings { get; set; }
    }
}