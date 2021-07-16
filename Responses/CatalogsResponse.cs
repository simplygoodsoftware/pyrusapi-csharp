using Newtonsoft.Json;
using Pyrus.ApiClient.Entities;
using PyrusApiClient;
using System.Collections.Generic;

namespace Pyrus.ApiClient.Responses
{
	public class CatalogsResponse : ResponseBase
	{
		[JsonProperty("catalogs")]
		public List<CatalogInfo> Catalogs { get; set; }
	}
}
