using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
    /// <summary>
    /// Запрос для регистрации в Pyrus звонка из системы API-телефонии.
    /// У оператора в браузере открывается новая вкладка с заявкой клиента.
    /// </summary>
    public class CallRequest
    {
        /// <summary>
        /// Уникальный идентификатор аккаунта интеграции во внешней системе
        /// </summary>
        /// <remarks>
        /// ID группы в ВКонтакте, имя бота в Telegram, ID бизнес аккаунта Facebook итд
        /// </remarks>
        [JsonProperty(PropertyName = "account_id")]
        public string AccountId { get; set; }
        
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
        /// Внутренний номер оператора
        /// </summary>
        /// <remarks>Заполнять не обязательно</remarks>
        [JsonProperty(PropertyName = "internal_number")]
        public string InternalNumber { get; set; }

        /// <summary>
        /// Идентификатор звонка во внешней системе
        /// </summary>
        /// <remarks>Заполнять не обязательно</remarks>
        [JsonProperty(PropertyName = "external_id")]
        public string ExternalId { get; set; }
        
        /// <summary>
        /// Данные для автоматического заполнения полей формы
        /// </summary>
        [JsonProperty(PropertyName = "mappings")]
        public List<FormMapping> Mappings { get; set; }
    }
}