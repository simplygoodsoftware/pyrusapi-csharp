using System;

namespace PyrusApiClient.Exceptions
{
    public class InvalidServerResponeException : PyrusApiClientException
    {
        public InvalidServerResponeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
