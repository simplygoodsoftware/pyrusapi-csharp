using PyrusApiClient;

namespace Pyrus.ApiClient.Requests.Builders
{
	public class OnePropertyBuilder<T, TResponse> where TResponse : ResponseBase
	{
		internal T Property { get; set; }

		internal OnePropertyBuilder(T intProperty)
		{
			Property = intProperty;
		}
	}
}
