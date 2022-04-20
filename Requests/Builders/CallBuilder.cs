using PyrusApiClient;

namespace Pyrus.ApiClient.Requests.Builders
{
    public class CallBuilder
    {
        private readonly CallRequest _request = new CallRequest();
		
        public CallBuilder WithAccountId(string accountId)
        {
            _request.AccountId = accountId;
            return this;
        }
		
        public CallBuilder FromNumber(string number)
        {
            _request.FromNumber = number;
            return this;
        }
		
        public CallBuilder ToNumber(string number)
        {
            _request.ToNumber = number;
            return this;
        }
		
        public CallBuilder WithInternalNumber(string internalNumber)
        {
            _request.InternalNumber = internalNumber;
            return this;
        }
		
        public CallBuilder WithExternalId(string externalId)
        {
            _request.ExternalId = externalId;
            return this;
        }
		
        public CallBuilder AddMapping(string code, string value)
        {
            _request.Mappings.Add(new FormMapping
            {
                Code = code, Value = value
            });
            return this;
        }

        public static implicit operator CallRequest(CallBuilder builder)
        {
            return builder._request;
        }
    }
}