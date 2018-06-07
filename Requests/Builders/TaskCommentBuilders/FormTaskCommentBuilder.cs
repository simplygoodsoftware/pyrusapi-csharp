using System;
using System.Collections.Generic;
using System.Linq;

namespace PyrusApiClient.Builders
{
	public class FormTaskCommentBuilder : TaskCommentBuilderBase<FormTaskCommentBuilder>
	{
		public int TaskId { get; }

		internal FormTaskCommentBuilder(TaskCommentRequest comment) : base(comment)
		{
		}

		internal FormTaskCommentBuilder(TaskCommentRequest comment, int taskId) : base(comment)
		{
			TaskId = taskId;
		}

		public FormTaskCommentBuilder AddApprovals(IEnumerable<IEnumerable<Approval>> approvals)
		{
			foreach (var approval in approvals.SelectMany(a => a))
				AddApproval(approval);

			return this;
		}

		public FormTaskCommentBuilder AddApproval(int personId, int step = 1)
		{
			var approval = new Approval { Step = step, Person = new Person { Id = personId } };
			return AddApproval(approval);
		}

		public FormTaskCommentBuilder AddApproval(string email, int step = 1)
		{
			var approval = new Approval { Step = step, Person = new Person { Email = email } };
			return AddApproval(approval);
		}

		public FormTaskCommentBuilder AddApproval(Person person, int step = 1)
		{
			var approval = new Approval { Step = step, Person = person };
			return AddApproval(approval);
		}

		public FormTaskCommentBuilder AddApproval(Approval approval)
		{
			if (!approval.Step.HasValue || approval.Step < 1)
				throw new ArgumentException("Step should start from 1");

			ApprovalsAdded.Add(approval);
			return this;
		}

		public FormTaskCommentBuilder RemoveApprovals(IEnumerable<IEnumerable<Approval>> approvals)
		{
			foreach (var approval in approvals.SelectMany(a => a))
				RemoveApproval(approval);

			return this;
		}

		public FormTaskCommentBuilder RemoveApproval(int personId, int step = 1)
		{
			var approval = new Approval { Step = step, Person = new Person { Id = personId } };
			return RemoveApproval(approval);
		}

		public FormTaskCommentBuilder RemoveApproval(string email, int step = 1)
		{
			var approval = new Approval { Step = step, Person = new Person { Email = email } };
			return RemoveApproval(approval);
		}

		public FormTaskCommentBuilder RemoveApproval(Person person, int step = 1)
		{
			var approval = new Approval { Step = step, Person = person };
			return RemoveApproval(approval);
		}

		public FormTaskCommentBuilder RemoveApproval(Approval approval)
		{
			if (!approval.Step.HasValue || approval.Step < 1)
				throw new ArgumentException("Step should start from 1");

			ApprovalsRemoved.Add(approval);
			return this;
		}

		public FormTaskCommentBuilder RerequestApprovals(IEnumerable<IEnumerable<Approval>> approvals)
		{
			foreach (var approval in approvals.SelectMany(a => a))
				RerequestApprovals(approval);

			return this;
		}

		public FormTaskCommentBuilder RerequestApprovals(int personId, int step = 1)
		{
			var approval = new Approval { Step = step, Person = new Person { Id = personId } };
			return RerequestApprovals(approval);
		}

		public FormTaskCommentBuilder RerequestApprovals(string email, int step = 1)
		{
			var approval = new Approval { Step = step, Person = new Person { Email = email } };
			return RerequestApprovals(approval);
		}

		public FormTaskCommentBuilder RerequestApprovals(Person person, int step = 1)
		{
			var approval = new Approval { Step = step, Person = person };
			return RerequestApprovals(approval);
		}

		public FormTaskCommentBuilder RerequestApprovals(Approval approval)
		{
			if (!approval.Step.HasValue || approval.Step < 1)
				throw new ArgumentException("Step should start from 1");

			ApprovalsRerequested.Add(approval);
			return this;
		}

		public FormTaskCommentBuilder Approve()
		{
			Comment.ApprovalChoice = ApprovalChoice.Approved;
			return this;
		}

		public FormTaskCommentBuilder Reject()
		{
			Comment.ApprovalChoice = ApprovalChoice.Rejected;
			return this;
		}

		public FormTaskCommentBuilder Revoke()
		{
			Comment.ApprovalChoice = ApprovalChoice.Revoked;
			return this;
		}

		public FormTaskCommentBuilder Acknowledge()
		{
			Comment.ApprovalChoice = ApprovalChoice.Acknowledged;
			return this;
		}

		public FormTaskCommentBuilder OnStep(int step)
		{
			Comment.ApprovalSteps.Add(step);
			return this;
		}

		public FormTaskCommentBuilder OnSteps(params int[] steps)
		{
			Comment.ApprovalSteps.AddRange(steps);
			return this;
		}

		public FormTaskCommentBuilder OnSteps(IEnumerable<int> steps)
		{
			Comment.ApprovalSteps.AddRange(steps);
			return this;
		}

		public FieldUpdatesBuilder FieldUpdates
		{
			get
			{
				if (ApprovalsAdded.Count != 0)
					BuilderHelper.WriteApprovals(ApprovalsAdded, Comment.ApprovalsAdded);

				if (ApprovalsRemoved.Count != 0)
					BuilderHelper.WriteApprovals(ApprovalsRemoved, Comment.ApprovalsRemoved);

				if (ApprovalsRerequested.Count != 0)
					BuilderHelper.WriteApprovals(ApprovalsRemoved, Comment.ApprovalsRerequested);

				return new FieldUpdatesBuilder(this, TaskId);
			}
		} 

		public class FieldUpdatesBuilder
		{
			private readonly FormTaskCommentBuilder _formTaskCommentBuilder;
			public int TaskId { get; }

			public FieldUpdatesBuilder(FormTaskCommentBuilder formTaskCommentBuilder, int taskId)
			{
				_formTaskCommentBuilder = formTaskCommentBuilder;
				TaskId = taskId;
			}

			public FieldUpdatesBuilder Add(FormField field)
			{
				_formTaskCommentBuilder.Comment.FieldUpdates.Add(field);
				return this;
			}

			public FormTaskCommentBuilder BuildFieldUpdates()
			{
				return _formTaskCommentBuilder;
			}

			public static implicit operator FormTaskCommentBuilder(FieldUpdatesBuilder builder)
			{
				return builder._formTaskCommentBuilder;
			}

			public static implicit operator TaskCommentRequest(FieldUpdatesBuilder builder)
			{
				return builder._formTaskCommentBuilder;
			}
		}
	}
}
