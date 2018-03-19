using System;
using System.Collections.Generic;
using System.Linq;

namespace PyrusApiClient.Builders
{
	public class SimpleTaskCommentBuilder : TaskCommentBuilderBase<SimpleTaskCommentBuilder>
	{
		public int TaskId { get;}

		internal SimpleTaskCommentBuilder(TaskCommentRequest comment) : base(comment)
		{
		}

		internal SimpleTaskCommentBuilder(TaskCommentRequest comment, int taskId) : base(comment)
		{
			TaskId = taskId;
		}

		public SimpleTaskCommentBuilder AddParticipants(IEnumerable<Person> participants)
		{
			Comment.ParticipantsAdded.AddRange(participants);
			return this;
		}

		public SimpleTaskCommentBuilder AddParticipants(IEnumerable<int> participantIds)
		{
			Comment.ParticipantsAdded.AddRange(participantIds.Select(id => new Person { Id = id }));
			return this;
		}

		public SimpleTaskCommentBuilder AddParticipants(IEnumerable<string> emails)
		{
			Comment.ParticipantsAdded.AddRange(emails.Select(email => new Person { Email = email }));
			return this;
		}

		public SimpleTaskCommentBuilder AddParticipant(Person participant)
		{
			Comment.ParticipantsAdded.Add(participant);
			return this;
		}

		public SimpleTaskCommentBuilder AddParticipant(int participantId)
		{
			Comment.ParticipantsAdded.Add(new Person { Id = participantId });
			return this;
		}

		public SimpleTaskCommentBuilder AddParticipant(string email)
		{
			Comment.ParticipantsRemoved.Add(new Person { Email = email });
			return this;
		}

		public SimpleTaskCommentBuilder RemoveParticipants(IEnumerable<Person> participants)
		{
			Comment.ParticipantsRemoved.AddRange(participants);
			return this;
		}

		public SimpleTaskCommentBuilder RemoveParticipants(IEnumerable<int> participantIds)
		{
			Comment.ParticipantsRemoved.AddRange(participantIds.Select(id => new Person { Id = id }));
			return this;
		}

		public SimpleTaskCommentBuilder RemoveParticipants(IEnumerable<string> emails)
		{
			Comment.ParticipantsRemoved.AddRange(emails.Select(email => new Person { Email = email }));
			return this;
		}

		public SimpleTaskCommentBuilder RemoveParticipant(Person participant)
		{
			Comment.ParticipantsRemoved.Add(participant);
			return this;
		}

		public SimpleTaskCommentBuilder RemoveParticipant(int participantId)
		{
			Comment.ParticipantsRemoved.Add(new Person { Id = participantId });
			return this;
		}

		public SimpleTaskCommentBuilder RemoveParticipant(string email)
		{
			Comment.ParticipantsRemoved.Add(new Person { Email = email });
			return this;
		}

		public SimpleTaskCommentBuilder WithDueDate(DateTime date)
		{
			if (Comment.Due.HasValue)
				throw new ArgumentException("Cannot set both DueDate and Due");

			Comment.DueDate = date;

			return this;
		}

		public SimpleTaskCommentBuilder WithDue(DateTime dateTime, int? duration = null)
		{
			if (Comment.DueDate.HasValue)
				throw new ArgumentException("Cannot set both DueDate and Due");

			Comment.Due = dateTime;
			Comment.Duration = duration;
			return this;
		}

		public SimpleTaskCommentBuilder ScheduledFor(DateTime date)
		{
			Comment.CancelSchedule = null;
			Comment.ScheduledDate = date;
			return this;
		}

		public SimpleTaskCommentBuilder CancelSchedule()
		{
			Comment.ScheduledDate = null;
			Comment.CancelSchedule = true;
			return this;
		}
	}
}
