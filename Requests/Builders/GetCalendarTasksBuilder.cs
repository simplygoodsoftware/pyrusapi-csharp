using System;
using PyrusApiClient;

namespace Pyrus.ApiClient.Requests.Builders
{
	public class GetCalendarTasksBuilder
	{
		private readonly CalendarTasksRequest _calendarTasksRequest = new CalendarTasksRequest();

		public GetCalendarTasksBuilder(DateTime startDateUtc, DateTime endDateUtc)
		{
			_calendarTasksRequest.StartDateUtc = startDateUtc;
			_calendarTasksRequest.EndDateUtc = endDateUtc;
			_calendarTasksRequest.FilterMask = 0b0111;
		}

		public GetCalendarTasksBuilder WithMaxItems(int maxTasks)
		{
			_calendarTasksRequest.ItemCount = maxTasks;
			return this;
		}

		/// <summary>
		/// if true, response return tasks from all user's roles and from all forms, which user has access, else only inbox tasks 
		/// </summary>
		/// <returns></returns>
		public GetCalendarTasksBuilder GetAllAccessedTasks(bool allTasks)
		{
			_calendarTasksRequest.AllAccessedTasks = allTasks;
			return this;
		}

		public GetCalendarTasksBuilder WithReminded(bool withReminded)
		{
			if (withReminded)
			{
				_calendarTasksRequest.FilterMask |= 0b1000;
			}
			else
			{
				_calendarTasksRequest.FilterMask &= ~0b1000;
			}
			return this;
		}

		public static implicit operator CalendarTasksRequest(GetCalendarTasksBuilder builder)
		{
			return builder._calendarTasksRequest;
		}
	}
}
