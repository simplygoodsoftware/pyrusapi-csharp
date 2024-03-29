﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PyrusApiClient.Builders
{
	public abstract class TaskBuilderBase<T> where T : TaskBuilderBase<T>
	{
		protected readonly List<Approval> Approvals = new List<Approval>();
		protected readonly TaskRequest Task;

		protected TaskBuilderBase(TaskRequest task)
		{
			Task = task;
		}

		public T WithText(string text)
		{
			Task.FormattedText = null;
			Task.Text = text;
			return (T)this;
		}

		public T WithFormattedText(string text)
		{
			Task.Text = null;
			Task.FormattedText = text;
			return (T)this;
		}

		public static implicit operator TaskRequest(TaskBuilderBase<T> tb)
		{
			if (tb.Approvals.Count != 0)
				BuilderHelper.WriteApprovals(tb.Approvals, tb.Task.Approvals);

			return tb.Task;
		}

		public T HasParent(int parentTaskId)
		{
			Task.ParentTaskId = parentTaskId;
			return (T)this;
		}

		public T AddAttachment(NewFile attachment)
		{
			Task.Attachments.Add(attachment);
			return (T)this;
		}

		public T AddAttachments(IEnumerable<NewFile> attachments)
		{
			Task.Attachments.AddRange(attachments);
			return (T)this;
		}

		[Obsolete]
		public T AddAttachment(Guid guid, int? rootId = null)
		{
			Task.Attachments.Add(new NewFile(guid.ToString(), rootId));
			return (T)this;
		}

		[Obsolete]
		public T AddAttachments(IEnumerable<Guid> attachments)
		{
			Task.Attachments.AddRange(attachments.Select(guid => new NewFile(guid.ToString())));
			return (T)this;
		}

		[Obsolete]
		public T AddAttachment(string guid, int? rootId = null)
		{
			Task.Attachments.Add(new NewFile(guid, rootId));
			return (T)this;
		}

		[Obsolete]
		public T AddAttachments(IEnumerable<string> attachments)
		{
			Task.Attachments.AddRange(attachments.Select(guid => new NewFile(guid)));
			return (T)this;
		}

		public T AddToList(int listId)
		{
			Task.ListIds.Add(listId);
			return (T)this;
		}

		public T AddToLists(IEnumerable<int> listIds)
		{
			Task.ListIds.AddRange(listIds);
			return (T)this;
		}

		public T ScheduledFor(DateTime date)
		{
			Task.ScheduledDateTimeUtc = null;
			Task.ScheduledDate = date;
			return (T)this;
		}

		public T ScheduledForDateTimeUtc(DateTime date)
		{
			Task.ScheduledDate = null;
			Task.ScheduledDateTimeUtc = date;
			return (T)this;
		}

		public T AddSubscribers(IEnumerable<Person> subscribers)
		{
			Task.Subscribers.AddRange(subscribers);
			return (T)this;
		}
		public T AddSubscribers(IEnumerable<int> subscriberIds) => AddSubscribers(subscriberIds.Select(id => new Person { Id = id }));
		public T AddSubscribers(IEnumerable<string> emails) => AddSubscribers(emails.Select(email => new Person { Email = email }));


		public T AddSubscriber(Person subscriber)
		{
			Task.Subscribers.Add(subscriber);
			return (T)this;
		}
		public T AddSubscriber(int subscriberId) => AddSubscriber(new Person { Id = subscriberId });
		public T AddSubscriber(string email) => AddSubscriber(new Person { Email = email });
	}
}
	
