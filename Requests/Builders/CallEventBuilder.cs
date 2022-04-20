using System;

namespace PyrusApiClient
{
    public class CallEventBuilder
    {
        private readonly CallEventRequest _request = new CallEventRequest();
        public readonly Guid CallGuid;

        public CallEventBuilder(Guid callGuid, CallEventType eventType = CallEventType.Show)
        {
            CallGuid = callGuid;
            _request.EventType = eventType;
        }

        public CallEventBuilder WithExtension(string extension)
        {
            _request.Extension = extension;
            return this;
        }

        public static implicit operator CallEventRequest(CallEventBuilder builder)
        {
            return builder._request;
        }
    }
}