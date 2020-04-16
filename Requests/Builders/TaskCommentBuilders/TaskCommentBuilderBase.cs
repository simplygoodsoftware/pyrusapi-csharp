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

		public T AddAttachment(NewFile attachment)
		{
			Comment.Attachments.Add(attachment);
			return (T)this;
		}

		public T AddAttachments(IEnumerable<NewFile> attachments)
		{
			Comment.Attachments.AddRange(attachments);
			return (T)this;
		}

		[Obsolete]
		public T AddAttachment(Guid guid, int? rootId = null)
		{
			Comment.Attachments.Add(new NewFile(guid.ToString(), rootId));
			return (T)this;
		}

		[Obsolete]
		public T AddAttachments(IEnumerable<Guid> attachments)
		{
			Comment.Attachments.AddRange(attachments.Select(guid => new NewFile(guid.ToString())));
			return (T)this;
		}

		[Obsolete]
		public T AddAttachment(string guid, int? rootId = null)
		{
			Comment.Attachments.Add(new NewFile(guid, rootId));
			return (T)this;
		}

		[Obsolete]
		public T AddAttachments(IEnumerable<string> attachments)
		{
			Comment.Attachments.AddRange(attachments.Select(guid => new NewFile(guid)));
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
			Comment.ScheduledDateTimeUtc = null;
			Comment.ScheduledDate = date;
			return (T)this;
		}

		public T ScheduledForDateTimeUtc(DateTime date)
		{
			Comment.CancelSchedule = null;
			Comment.ScheduledDate = null;
			Comment.ScheduledDateTimeUtc = date;
			return (T)this;
		}

		public T CancelSchedule()
		{
			Comment.ScheduledDate = null;
			Comment.ScheduledDateTimeUtc = null;
			Comment.CancelSchedule = true;
			return (T)this;
		}

		public T Reassign(Person person)
		{
			Comment.ReassignTo = person;
			return (T)this;
		}

		public T Reassign(int personId) => Reassign(new Person { Id = personId });
		public T Reassign(string email) => Reassign(new Person { Email = email });
	}
}
