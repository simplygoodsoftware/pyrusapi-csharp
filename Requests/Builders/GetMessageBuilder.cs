using System;
using System.Collections.Generic;
using PyrusApiClient;

namespace Pyrus.ApiClient.Requests.Builders
{
    public class GetMessageBuilder
    {
        private readonly GetMessageRequest _request = new GetMessageRequest
        {
            Mappings = new List<FormMapping>(),
            Attachments = new List<Guid>()
        };
		
        public GetMessageBuilder WithAccountId(string accountId)
        {
            _request.AccountId = accountId;
            return this;
        }
		
        public GetMessageBuilder WithChannelId(string channelId)
        {
            _request.ChannelId = channelId;
            return this;
        }
		
        public GetMessageBuilder WithSenderName(string senderName)
        {
            _request.SenderName = senderName;
            return this;
        }
		
        public GetMessageBuilder WithMessage(string messageType, string messageText)
        {
            _request.MessageType = messageType;
            _request.MessageText = messageText;
            return this;
        }
		
        public GetMessageBuilder AddMapping(string code, string value)
        {
            _request.Mappings.Add(new FormMapping
            {
                Code = code, Value = value
            });
            return this;
        }
		
        public GetMessageBuilder AddAttachment(Guid attachmentId)
        {
            _request.Attachments.Add(attachmentId);
            return this;
        }

        public static implicit operator GetMessageRequest(GetMessageBuilder builder)
        {
            return builder._request;
        }
    }
}