using System;

namespace PyrusApiClient
{
    public class CreateCallBuilder
    {
        private readonly CreateCallRequest _request = new CreateCallRequest();

        public CreateCallBuilder(Guid integrationGuid)
        {
            _request.IntegrationGuid = integrationGuid;
        }

        public CreateCallBuilder From(string number)
        {
            _request.From = number;
            return this;
        }

        public CreateCallBuilder To(string number)
        {
            _request.To = number;
            return this;
        }

        public CreateCallBuilder WithExtension(string extension)
        {
            _request.Extension = extension;
            return this;
        }

        public static implicit operator CreateCallRequest(CreateCallBuilder builder)
        {
            return builder._request;
        }
    }
}