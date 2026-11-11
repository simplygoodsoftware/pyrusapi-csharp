namespace Pyrus.ApiClient.Requests.Builders
{
	public class CreateBotRequestBuilder
	{
		private readonly CreateBotRequest _request;

		public CreateBotRequestBuilder(string name)
		{
			_request = new CreateBotRequest
			{
				Name = name
			};
		}

		public CreateBotRequestBuilder Linked(string hookUrl)
		{
			_request.HookUrl = hookUrl;
			return this;
		}

		/// <summary>
		/// Sets the IDs of the initial bot supervisors. Each call replaces the list in the request.
		/// </summary>
		/// <param name="personIds">IDs of the people to assign as supervisors.</param>
		public CreateBotRequestBuilder SetSupervisors(params int[] personIds)
		{
			_request.AddSupervisors = personIds;
			return this;
		}

		public static implicit operator CreateBotRequest(CreateBotRequestBuilder cbrb)
		{
			return cbrb._request;
		}
	}
}
