using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyrus.ApiClient.Requests.Builders
{
	public class UpdateBotRequestBuilder
	{
		public int BotId { get; }
		private readonly UpdateBotRequest _request;

		public UpdateBotRequestBuilder(int botId)
		{
			_request = new UpdateBotRequest();
			BotId = botId;
		}

		public UpdateBotRequestBuilder Relink(string hookUrl)
		{
			_request.HookUrl = hookUrl;
			return this;
		}

		public UpdateBotRequestBuilder AddUrlValidation()
		{
			_request.NeedUrlValidation = true;
			return this;
		}

		public UpdateBotRequestBuilder RemoveUrlValidation()
		{
			_request.NeedUrlValidation = true;
			return this;
		}

		public UpdateBotRequestBuilder Enable()
		{
			_request.IsEnabled = true;
			return this;
		}

		public UpdateBotRequestBuilder Disable()
		{
			_request.IsEnabled = false;
			return this;
		}
		
		public UpdateBotRequestBuilder UpdateSecretKey()
		{
			_request.UpdateSecretKey = true;
			return this;
		}

		public UpdateBotRequestBuilder ChangeSettings(string botSettings)
		{
			_request.BotSettings = botSettings;
			return this;
		}

		public UpdateBotRequestBuilder ChangeDescription(string botDescription)
		{
			_request.BotDescription = botDescription;
			return this;
		}

		public static implicit operator UpdateBotRequest(UpdateBotRequestBuilder cbrb)
		{
			return cbrb._request;
		}
	}
}
