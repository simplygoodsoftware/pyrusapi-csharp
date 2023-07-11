using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyrus.ApiClient.Requests
{
    public class SetAvatarRequest
    {
        [JsonProperty(PropertyName = "guid")]
        public Guid? Guid { get; set; }

        [JsonProperty(PropertyName = "cloud_avatar_id")]
        public int? CloudAvatarId { get; set; }
    }
}
