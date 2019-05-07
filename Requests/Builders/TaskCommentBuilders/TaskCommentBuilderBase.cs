using System;
using System.Collections.Generic;
using System.Linq;

namespace PyrusApiClient.Builders
{
	public abstract class TaskCommentBuilderBase<T> where T : TaskCommentBuilderBase<T>
	{
		protected readonly TaskCommentRequest Comment;
		protected readonly List<Approval> ApprovalsAdded = new List<Approval>();
		protected readonly List<Approval> ApprovalsRemoved = new List<Approval>();
		protected readonly List<Approval> ApprovalsRerequested = new List<Approval>();

		protected TaskCommentBuilderBase(TaskCommentRequest comment)
		{
			Comment = comment;
		}

		public static implicit operator TaskCommentRequest(TaskCommentBuilderBase<T> tcb)
		{
			if (tcb.ApprovalsAdded.Count != 0)
				BuilderHelper.WriteApprovals(tcb.ApprovalsAdded, tcb.Comment.ApprovalsAdded);

			if (tcb.ApprovalsRemoved.Count != 0)
				BuilderHelper.WriteApprovals(tcb.ApprovalsRemoved, tcb.Comment.ApprovalsRemoved);

			if (tcb.ApprovalsRerequested.Count != 0)
				BuilderHelper.WriteApprovals(tcb.ApprovalsRerequested, tcb.Comment.ApprovalsRerequested);

			return tcb.Comment;
		}

		public T WithText(string text)
		{
			Comment.Text = text;
			return (T) this;
		}

		public T WithAction(ActivityAction action)
		{
			Comment.Action = action;
			return (T) this;
		}

		public T AddAttachments(IEnumerable<Guid> attachments)
		{
			Comment.Attachments.AddRange(attachments.Select(guid => new NewFile{Guid = guid.ToString() }));
			return (T)this;
		}

		public T AddAttachments(IEnumerable<string> attachments)
		{
			Comment.Attachments.AddRange(attachments.Select(guid => new NewFile { Guid = guid }));
			return (T)this;
		}

		public T AddAttachment(Guid guid, int? rootId = null)
		{
			Comment.Attachments.Add(new NewFile { Guid = guid.ToString(), RootId = rootId });
			return (T)this;
		}

		public T AddAttachment(string guid, int? rootId = null)
		{
			Comment.Attachments.Add(new NewFile { Guid = guid, RootId = rootId });
			return (T)this;
		}

		public T AddToList(int listId)
		{
			Comment.AddedListIds.Add(listId);
			return (T)this;
		}

		public T AddToList(IEnumerable<int> listIds)
		{
			Comment.AddedListIds.AddRange(listIds);
			return (T)this;
		}

		public T RemoveFromList(int listId)
		{
			Comment.RemovedListIds.Add(listId);
			return (T)this;
		}

		public T RemoveFromList(IEnumerable<int> listIds)
		{
			Comment.RemovedListIds.AddRange(listIds);
			return (T)this;
		}

		public T ScheduledFor(DateTime date)
		{
			Comment.CancelSchedule = null;
			Comment.ScheduledDate = date;
			return (T)this;
		}

		public T ScheduledForDateTimeUtc(DateTime date)
		{
			Comment.CancelSchedule = null;
			Comment.ScheduledDateTimeUtc = date;
			return (T)this;
		}

		public T CancelSchedule()
		{
			Comment.ScheduledDate = null;
			Comment.CancelSchedule = true;
			return (T)this;
		}
	}
}
