using Newtonsoft.Json;
using PyrusApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyrus.ApiClient.Responses
{
	public class BotsResponse : ResponseBase
	{
		[JsonProperty(PropertyName = "bots")]
		public List<Bot> Bots { get; set; } = new List<Bot>();
	}
}
