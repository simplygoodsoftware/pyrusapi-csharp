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

		protected readonly List<Subscriber> SubscribersAdded = new List<Subscriber>();
		protected readonly List<Subscriber> SubscribersRemoved = new List<Subscriber>();
		protected readonly List<Subscriber> SubscribersRerequested = new List<Subscriber>();

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

			if (tcb.SubscribersAdded.Count != 0)
				tcb.Comment.SubscribersAdded= tcb.SubscribersAdded.Select(x => x.Person).ToList();

			if (tcb.SubscribersRemoved.Count != 0)
				tcb.Comment.SubscribersRemoved= tcb.SubscribersRemoved.Select(x => x.Person).ToList();

			if (tcb.SubscribersRerequested.Count != 0)
				tcb.Comment.SubscribersRerequested = tcb.SubscribersRerequested.Select(x => x.Person).ToList();

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

		public T WithSpentMinutes(int spentMinutes)
		{
			Comment.SpentMinutes = spentMinutes;
			return (T)this;
		}
        #region subscribers
        public T AddSubscribers(IEnumerable<Person> subscribers)
		{
			Comment.SubscribersAdded.AddRange(subscribers);
			return (T)this;
		}
		public T AddSubscribers(IEnumerable<int> subscriberIds) => AddSubscribers(subscriberIds.Select(id => new Person { Id = id }));
		public T AddSubscribers(IEnumerable<string> emails) => AddSubscribers(emails.Select(email => new Person { Email = email }));


		public T AddSubscriber(Person subscriber)
		{
			Comment.SubscribersAdded.Add(subscriber);
			return (T)this;
		}
		public T AddSubscriber(int subscriberId) => AddSubscriber(new Person { Id = subscriberId });
		public T AddSubscriber(string email) => AddSubscriber(new Person { Email = email });

		public T RemoveSubscribers(IEnumerable<Person> subscribers)
		{
			Comment.SubscribersRemoved.AddRange(subscribers);
			return (T)this;
		}
		public T RemoveSubscribers(IEnumerable<int> subscriberIds) => RemoveSubscribers(subscriberIds.Select(id => new Person { Id = id }));
		public T RemoveSubscribers(IEnumerable<string> emails) => RemoveSubscribers(emails.Select(email => new Person { Email = email }));
		
		public T RemoveSubscriber(Person subscriber)
		{
			Comment.SubscribersRemoved.Add(subscriber);
			return (T)this;
		}
		public T RemoveSubscriber(int subscriberId) => RemoveSubscriber(new Person { Id = subscriberId });
		public T RemoveSubscriber(string email) => RemoveSubscriber(new Person { Email = email });
		
		public T RerequestSubscribers(IEnumerable<Person> subscribers)
		{
			Comment.SubscribersRerequested.AddRange(subscribers);
			return (T)this;
		}
		public T RerequestSubscribers(IEnumerable<int> subscriberIds) => RerequestSubscribers(subscriberIds.Select(id => new Person { Id = id }));
		public T RerequestSubscribers(IEnumerable<string> emails) => RerequestSubscribers(emails.Select(email => new Person { Email = email }));
		
		public T RerequestSubscriber(Person subscriber)
		{
			Comment.SubscribersRerequested.Add(subscriber);
			return (T)this;
		}
		public T RerequestSubscriber(int subscriberId) => RerequestSubscriber(new Person { Id = subscriberId });
		public T RerequestSubscriber(string email) => RerequestSubscriber(new Person { Email = email });

        #endregion

        public T Approve()
		{
			Comment.ApprovalChoice = ApprovalChoice.Approved;
			return (T)this;
		}

		public T Reject()
		{
			Comment.ApprovalChoice = ApprovalChoice.Rejected;
			return (T)this;
		}

		public T Revoke()
		{
			Comment.ApprovalChoice = ApprovalChoice.Revoked;
			return (T)this;
		}

		public T Acknowledge()
		{
			Comment.ApprovalChoice = ApprovalChoice.Acknowledged;
			return (T)this;
		}
	}
}
