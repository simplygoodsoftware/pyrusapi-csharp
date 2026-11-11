using Pyrus.ApiClient.Enums;
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

		public UpdateBotRequestBuilder ChangeRights(PersonRights rights)
		{
			_request.Rights = rights;
			return this;
		}

		/// <summary>
		/// Sets which supervisors to add. Each call replaces the list of additions in the request.
		/// </summary>
		/// <param name="personIds">IDs of the people to add as supervisors.</param>
		public UpdateBotRequestBuilder SetSupervisorsToAdd(params int[] personIds)
		{
			_request.AddSupervisors = personIds;
			return this;
		}

		/// <summary>
		/// Sets which supervisors to remove. Each call replaces the list of removals in the request.
		/// </summary>
		/// <param name="personIds">IDs of the people to remove from the supervisors list.</param>
		public UpdateBotRequestBuilder SetSupervisorsToRemove(params int[] personIds)
		{
			_request.RemoveSupervisors = personIds;
			return this;
		}

		public static implicit operator UpdateBotRequest(UpdateBotRequestBuilder cbrb)
		{
			return cbrb._request;
		}
	}
}
