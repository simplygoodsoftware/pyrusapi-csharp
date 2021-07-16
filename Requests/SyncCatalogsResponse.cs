using Newtonsoft.Json;
using Pyrus.ApiClient.Entities;
using PyrusApiClient;
using System.Collections.Generic;

namespace Pyrus.ApiClient.Requests
{
	public class SyncCatalogsResponse : ResponseBase
	{
		[JsonProperty("catalogs")]
		public List<SyncCatalogResponse> Catalogs { get; set; }
	}
}
