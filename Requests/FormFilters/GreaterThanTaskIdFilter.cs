using PyrusApiClient;

namespace Pyrus.ApiClient.Requests.FormFilters
{
	public class GreaterThanTaskIdFilter : FormFilter
	{
		public GreaterThanTaskIdFilter(object value)
			: base(OperatorId.GreaterThan, true, value)
		{

		}
	}
}
