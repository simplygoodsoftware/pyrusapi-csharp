using PyrusApiClient;

namespace Pyrus.ApiClient.Requests.Builders
{
    public class AttachCallRecordBuilder
    {
        private readonly AttachCallRecordRequest _request = new AttachCallRecordRequest();

        public AttachCallRecordBuilder(string recordFile)
        {
            _request.RecordFile = recordFile;
        }
		
        public AttachCallRecordBuilder FromNumber(string number)
        {
            _request.FromNumber = number;
            return this;
        }
		
        public AttachCallRecordBuilder ToNumber(string number)
        {
            _request.ToNumber = number;
            return this;
        }
		
        public AttachCallRecordBuilder WithExternalId(string externalId)
        {
            _request.ExternalId = externalId;
            return this;
        }
		
        public AttachCallRecordBuilder WithTaskId(int taskId)
        {
            _request.TaskId = taskId;
            return this;
        }
		
        public AttachCallRecordBuilder AddMapping(string code, string value)
        {
            _request.Mappings.Add(new FormMapping
            {
                Code = code, Value = value
            });
            return this;
        }

        public static implicit operator AttachCallRecordRequest(AttachCallRecordBuilder builder)
        {
            return builder._request;
        }
    }
}