using Pyrus.ApiClient.Entities;

namespace PyrusApiClient
{
	public class SyncCatalogResponse : ResponseBase
	{
		public CatalogDiff Catalog { get; set; }
	}
}
