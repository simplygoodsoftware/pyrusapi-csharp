namespace PyrusApiClient.Builders
{
	public class UpdateCatalogRequestBuilder : CatalogBuilderBase<UpdateCatalogRequestBuilder>
	{
		public int CatalogId { get; }

		public UpdateCatalogRequestBuilder(int catalogId)
			:base(new UpdateCatalogRequest())
		{
			CatalogId = catalogId;
		}

		public UpdateCatalogRequestBuilder(UpdateCatalogRequest request, int catalogId)
			:base(request)
		{
			CatalogId = catalogId;
		}

		public static implicit operator UpdateCatalogRequest(UpdateCatalogRequestBuilder ucrb)
		{
			return ucrb.Request as UpdateCatalogRequest;
		}

		public UpdateCatalogRequestBuilder ApplyChanges(bool apply)
		{
			((UpdateCatalogRequest)Request).Apply = apply;
			return this;
		}
	}
}
