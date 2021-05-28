using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public CreateBotRequestBuilder Version(int botVersion)
		{
			_request.BotVersion = botVersion;
			return this;
		}

		public CreateBotRequestBuilder WithUrlValidation()
		{
			_request.NeedUrlValidation =  true;
			return this;
		}
		
		public CreateBotRequestBuilder WithoutUrlValidation()
		{
			_request.NeedUrlValidation =  true;
			return this;
		}

		public static implicit operator CreateBotRequest(CreateBotRequestBuilder cbrb)
		{
			return cbrb._request;
		}
	}
}
