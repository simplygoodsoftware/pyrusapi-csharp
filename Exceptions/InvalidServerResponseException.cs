using System;

namespace PyrusApiClient.Exceptions
{
    public class InvalidServerResponseException : PyrusApiClientException
    {
        public InvalidServerResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
