using PyrusApiClient;

namespace Pyrus.ApiClient.Requests.Builders
{
	public class OneIntPropertyBuilder<T> where T : ResponseBase
	{
		internal int IntProperty { get; set; }

		internal OneIntPropertyBuilder(int intProperty)
		{
			IntProperty = intProperty;
		}
	}
}
