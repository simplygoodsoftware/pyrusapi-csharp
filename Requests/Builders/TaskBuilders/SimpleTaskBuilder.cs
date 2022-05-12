using System;
using System.Collections.Generic;
using System.Linq;

namespace PyrusApiClient.Builders
{
	public class SimpleTaskBuilder : TaskBuilderBase<SimpleTaskBuilder>
	{
		public SimpleTaskBuilder(TaskRequest task) : base(task)
		{
		}


		public SimpleTaskBuilder WithSubject(string subject)
		{
			Task.Subject = subject;
			return this;
		}

		public SimpleTaskBuilder AssignedTo(Person person)
		{
			Task.Responsible = person;
			return this;
		}

		public SimpleTaskBuilder AssignedTo(int personId)
		{
			Task.Responsible = new Person {Id = personId};
			return this;
		}

		public SimpleTaskBuilder AssignedTo(string email)
		{
			Task.Responsible = new Person {Email = email};
			return this;
		}

		public SimpleTaskBuilder AddedToLists(IEnumerable<int> listIds)
		{
			Task.ListIds.AddRange(listIds);
			return this;
		}

		public SimpleTaskBuilder AddedToList(int listId)
		{
			Task.ListIds.Add(listId);
			return this;
		}

		public SimpleTaskBuilder WithDueDate(DateTime date)
		{
			if (Task.Due.HasValue)
				throw new ArgumentException("Cannot set both DueDate and Due");

			Task.DueDate = date;
			
			return this;
		}

		public SimpleTaskBuilder WithDue(DateTime dateTime, int? duration = null)
		{
			if (Task.DueDate.HasValue)
				throw new ArgumentException("Cannot set both DueDate and Due");

			Task.Due = dateTime;
			Task.Duration = duration;
			return this;
		}

		public SimpleTaskBuilder AddParticipants(IEnumerable<Person> participants)
		{
			Task.Participants.AddRange(participants);
			return this;
		}

		public SimpleTaskBuilder AddParticipants(IEnumerable<int> participantIds)
		{
			Task.Participants.AddRange(participantIds.Select(id => new Person{Id = id}));
			return this;
		}

		public SimpleTaskBuilder AddParticipants(IEnumerable<string> emails)
		{
			Task.Participants.AddRange(emails.Select(email => new Person { Email = email }));
			return this;
		}

		public SimpleTaskBuilder AddParticipant(Person participant)
		{
			Task.Participants.Add(participant);
			return this;
		}

		public SimpleTaskBuilder AddParticipant(int participantId)
		{
			Task.Participants.Add(new Person{ Id = participantId });
			return this;
		}

		public SimpleTaskBuilder AddParticipant(string email)
		{
			Task.Participants.Add(new Person {Email = email});
			return this;
		}
	}
}
