using System;
using System.Collections.Generic;
using System.Linq;

namespace PyrusApiClient.Builders
{
	public class FormTaskBuilder : TaskBuilderBase<FormTaskBuilder>
	{
		public FormTaskBuilder(TaskRequest task) : base(task)
		{
		}

		public FormTaskBuilder AddApprovals(IEnumerable<IEnumerable<Approval>> approvals)
		{
			foreach (var approval in approvals.SelectMany(a => a))
				AddApproval(approval);

			return this;
		}

		public FormTaskBuilder AddApproval(int personId, int step = 1)
		{
			var approval = new Approval { Step = step, Person = new Person { Id = personId } };
			return AddApproval(approval);
		}

		public FormTaskBuilder FillDefaults()
		{
			Task.FillDefaults = true;
			return this;
		}

		public FormTaskBuilder AddApproval(string email, int step = 1)
		{
			var approval = new Approval { Step = step, Person = new Person { Email = email } };
			return AddApproval(approval);
		}

		public FormTaskBuilder AddApproval(Person person, int step = 1)
		{
			var approval = new Approval { Step = step, Person = person };
			return AddApproval(approval);
		}

		public FormTaskBuilder AddApproval(Approval approval)
		{
			if (!approval.Step.HasValue || approval.Step < 1)
				throw new ArgumentException("Step should start from 1");

			Approvals.Add(approval);
			return this;
		}

		public FormFieldsBuilder Fields
		{
			get
			{
				if (Approvals != null)
					BuilderHelper.WriteApprovals(Approvals, Task.Approvals);

				return new FormFieldsBuilder(this);
			}
		} 

		public class FormFieldsBuilder
		{
			private readonly FormTaskBuilder _taskRequestBuilder;
			public FormFieldsBuilder(FormTaskBuilder taskRequestBuilder)
			{
				_taskRequestBuilder = taskRequestBuilder;
			}

			public FormFieldsBuilder Add(FormField field)
			{
				_taskRequestBuilder.Task.Fields.Add(field);
				return this;
			}

			public FormTaskBuilder BuidlFields()
			{
				return _taskRequestBuilder;
			}

			public static implicit operator TaskRequest(FormFieldsBuilder builder)
			{
				return builder._taskRequestBuilder;
			}
		}
	}
}
