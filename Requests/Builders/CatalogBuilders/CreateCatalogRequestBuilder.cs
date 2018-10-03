namespace PyrusApiClient.Builders
{
	public class CreateCatalogRequestBuilder : CatalogBuilderBase<CreateCatalogRequestBuilder>
	{

		public CreateCatalogRequestBuilder(string catalogName)
			:base(new CreateCatalogRequest { CatalogName = catalogName })
		{
		}
		
		public static implicit operator CreateCatalogRequest(CreateCatalogRequestBuilder ccrb)
		{
			return ccrb.Request as CreateCatalogRequest;
		}
	}
}
