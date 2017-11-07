using System;

namespace PyrusApiClient.Exceptions
{
	public class PyrusApiClientException : Exception
	{
		public PyrusApiClientException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public PyrusApiClientException(string message)
			: base(message)
		{
		}
	}
}
