using System;
using System.Collections.Generic;
using System.Linq;

namespace PyrusApiClient.Builders
{
	public abstract class TaskBuilderBase<T> where T: TaskBuilderBase<T>
	{
		protected readonly List<Approval> Approvals = new List<Approval>();
		protected readonly TaskRequest Task;

		protected TaskBuilderBase(TaskRequest task)
		{
			Task = task;
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

		public T AddAttachment(Guid guid, int? rootId = null)
		{
			Task.Attachments.Add(new NewFile(guid.ToString(), rootId));
			return (T)this;
		}

		public T AddAttachments(IEnumerable<Guid> attachments)
		{
			Task.Attachments.AddRange(attachments.Select(guid => new NewFile(guid.ToString(), rootId: null)));
			return (T)this;
		}

		public T AddAttachment(string guid, int? rootId = null)
		{
			Task.Attachments.Add(new NewFile(guid, rootId));
			return (T)this;
		}

		public T AddAttachments(IEnumerable<string> attachments)
		{
			Task.Attachments.AddRange(attachments.Select(guid => new NewFile(guid, rootId: null)));
			return (T)this;
		}

		public T AddAttachment(int attachmentId)
		{
			Task.Attachments.Add(new NewFile(attachmentId));
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
	}
}
