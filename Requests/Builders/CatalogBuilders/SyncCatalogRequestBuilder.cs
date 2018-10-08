namespace PyrusApiClient.Builders
{
	public class SyncCatalogRequestBuilder : CatalogBuilderBase<SyncCatalogRequestBuilder>
	{
		public int CatalogId { get; }

		public SyncCatalogRequestBuilder(int catalogId)
			:base(new SyncCatalogRequest())
		{
			CatalogId = catalogId;
		}

		public SyncCatalogRequestBuilder(SyncCatalogRequest request, int catalogId)
			:base(request)
		{
			CatalogId = catalogId;
		}

		public static implicit operator SyncCatalogRequest(SyncCatalogRequestBuilder ucrb)
		{
			return ucrb.Request as SyncCatalogRequest;
		}

		public SyncCatalogRequestBuilder ApplyChanges()
		{
			((SyncCatalogRequest)Request).Apply = true;
			return this;
		}
	}
}
