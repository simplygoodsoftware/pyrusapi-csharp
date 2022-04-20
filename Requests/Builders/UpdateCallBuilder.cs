using System;

namespace PyrusApiClient
{
    public class UpdateCallBuilder
    {
        private readonly UpdateCallRequest _request = new UpdateCallRequest();
        public readonly Guid CallGuid;

        public UpdateCallBuilder(Guid callGuid)
        {
            CallGuid = callGuid;
        }

        public UpdateCallBuilder WithStartTime(DateTime startTime)
        {
            _request.StartTime = startTime;
            return this;
        }
		
        public UpdateCallBuilder WithEndTime(DateTime endTime)
        {
            _request.EndTime = endTime;
            return this;
        }
		
        public UpdateCallBuilder WithRating(int rating)
        {
            _request.Rating = rating;
            return this;
        }
		
        public UpdateCallBuilder DisconnectedBy(DisconnectParty party)
        {
            _request.DisconnectParty = party;
            return this;
        }
		
        public UpdateCallBuilder WithStatus(CallStatus status)
        {
            _request.CallStatus = status;
            return this;
        }
		
        public UpdateCallBuilder WithFile(Guid fileGuid)
        {
            _request.FileGuid = fileGuid;
            return this;
        }

        public static implicit operator UpdateCallRequest(UpdateCallBuilder builder)
        {
            return builder._request;
        }
    }
}