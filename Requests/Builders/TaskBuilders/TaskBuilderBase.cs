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

		public T AddAttachments(IEnumerable<Guid> attachments)
		{
			Task.Attachments.AddRange(attachments.Select(guid => guid.ToString()));
			return (T)this;
		}

		public T AddAttachments(IEnumerable<string> attachments)
		{
			Task.Attachments.AddRange(attachments);
			return (T)this;
		}

		public T AddAttachment(Guid guid)
		{
			Task.Attachments.Add(guid.ToString());
			return (T)this;
		}

		public T AddAttachment(string guid)
		{
			Task.Attachments.Add(guid);
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
	}
}
