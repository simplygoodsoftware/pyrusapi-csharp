using Pyrus.ApiClient.Entities;

namespace PyrusApiClient
{
	public class CatalogResponse : ResponseBase
	{
		public OrgCatalog Catalog { get; set; }
	}
}
