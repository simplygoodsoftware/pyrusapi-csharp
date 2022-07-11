namespace PyrusApiClient.Builders
{
	public class GetCatalogRequestBuilder
	{
		public bool IncludeDeletedItems { get; private set; }
		public int CatalogId { get; }

		public GetCatalogRequestBuilder(int catalogId)
		{
			CatalogId = catalogId;
		}

		public GetCatalogRequestBuilder IncludeDeleted()
		{
			IncludeDeletedItems = true;
			return this;
		}
	}
}
