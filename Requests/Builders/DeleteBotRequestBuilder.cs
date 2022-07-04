namespace Pyrus.ApiClient.Requests.Builders
{
	public class DeleteBotRequestBuilder
	{
		private readonly DeleteBotRequest _request;
		public int BotId { get; }


		public DeleteBotRequestBuilder(int botId, int taskReceiverId)
		{
			BotId = botId;
			_request = new DeleteBotRequest
			{
				TaskReceiverId = taskReceiverId
			};
		}

		public static implicit operator DeleteBotRequest(DeleteBotRequestBuilder crb) => crb._request;

	}
}
