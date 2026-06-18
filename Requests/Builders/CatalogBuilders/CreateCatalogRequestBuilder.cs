using System;

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

		public CreateCatalogRequestBuilder WithSourceType(SourceType sourceType)
		{
			var request = Request as CreateCatalogRequest;
			request.SourceType = sourceType;
			return this;
		}

		public CreateCatalogRequestBuilder WithExternalLastSyncDate(DateTime? externalLastSyncDate)
		{
			var request = Request as CreateCatalogRequest;
			request.ExternalLastSyncDate = externalLastSyncDate;
			return this;
		}


		public CreateCatalogRequestBuilder WithExternalChangeDate(DateTime? externalChangeDate)
		{
			var request = Request as CreateCatalogRequest;
			request.ExternalChangeDate = externalChangeDate;
			return this;
		}		
	}
}
