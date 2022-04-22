using System;
using System.Collections.Generic;
using System.Linq;

namespace PyrusApiClient.Builders
{
	public class FormRegisterRequestBuilder
	{
		private readonly FormRegisterRequest _formRegisterRequest;
		public int FormId { get; }

		internal FormRegisterRequestBuilder(FormRegisterRequest formRegisterRequest)
		{
			_formRegisterRequest = formRegisterRequest;
		}
		internal FormRegisterRequestBuilder(FormRegisterRequest formRegisterRequest, int formId)
		{
			_formRegisterRequest = formRegisterRequest;
			FormId = formId;
		}

		public static implicit operator FormRegisterRequest(FormRegisterRequestBuilder frrb)
		{
			return frrb._formRegisterRequest;
		}

		public FormRegisterRequestBuilder OnSteps(IEnumerable<int> steps)
		{
			_formRegisterRequest.Steps = steps.ToList();
			return this;
		}

		public FormRegisterRequestBuilder OnSteps(params int[] steps)
		{
			_formRegisterRequest.Steps = steps.ToList();
			return this;
		}

		public FormRegisterRequestBuilder FilterByTaskIds(IEnumerable<int> tasks)
		{
			if (tasks == null)
				throw new ArgumentNullException(nameof(tasks));
			_formRegisterRequest.TaskIds = tasks.ToList();
			return this;
		}

		public FormRegisterRequestBuilder FilterByTaskIds(params int[] tasks)
		{
			if (tasks == null)
				throw new ArgumentNullException(nameof(tasks));
			_formRegisterRequest.TaskIds = tasks.ToList();
			return this;
		}

		public FormRegisterRequestBuilder FilterByDue(DueFilter due)
		{
			_formRegisterRequest.DueFilter = due ?? throw new ArgumentNullException(nameof(due));
			return this;
		}

		public FormRegisterRequestBuilder IncludingArchived()
		{
			_formRegisterRequest.IncludeArchived = true;
			return this;
		}

		public FormRegisterRequestBuilder ModifiedBefore(DateTime dateTime)
		{
			_formRegisterRequest.ModifiedBefore = dateTime;
			return this;
		}

		public FormRegisterRequestBuilder ModifiedAfter(DateTime dateTime)
		{
			_formRegisterRequest.ModifiedAfter = dateTime;
			return this;
		}

		public FormRegisterRequestBuilder CreatedBefore(DateTime dateTime)
		{
			_formRegisterRequest.CreatedBefore = dateTime;
			return this;
		}

		public FormRegisterRequestBuilder CreatedAfter(DateTime dateTime)
		{
			_formRegisterRequest.CreatedAfter = dateTime;
			return this;
		}

		public FormRegisterRequestBuilder ClosedBefore(DateTime dateTime)
		{
			_formRegisterRequest.ClosedBefore = dateTime;
			return this;
		}

		public FormRegisterRequestBuilder ClosedAfter(DateTime dateTime)
		{
			_formRegisterRequest.ClosedAfter = dateTime;
			return this;
		}

		public FormRegisterRequestBuilder OnlyClosed()
		{
			if (_formRegisterRequest.ClosedBefore.HasValue || _formRegisterRequest.ClosedAfter.HasValue)
				return this;

			_formRegisterRequest.ClosedBefore = DateTime.MaxValue;
			return this;
		}

		public FormRegisterRequestBuilder WithFields(IEnumerable<int> fieldIds)
		{
			_formRegisterRequest.FieldIds = fieldIds.ToList();
			return this;
		}

		public FormRegisterRequestBuilder WithFields(params int[] fieldIds)
		{
			_formRegisterRequest.FieldIds = fieldIds.ToList();
			return this;
		}

		public FormRegisterFilterBuilder FilteredBy => new FormRegisterFilterBuilder(this, FormId);

		public class FormRegisterFilterBuilder
		{
			private readonly FormRegisterRequestBuilder _formRegisterRequestBuilder;
			private int _currentFieldId;
			private string _currentFieldName;
			private bool? _byId;
			public int FormId { get; }

			public FormRegisterFilterBuilder(FormRegisterRequestBuilder formRegisterRequestBuilder, int formId)
			{
				_formRegisterRequestBuilder = formRegisterRequestBuilder;
				FormId = formId;
			}

			public static implicit operator FormRegisterRequest(FormRegisterFilterBuilder frfb)
			{
				return frfb._formRegisterRequestBuilder;
			}

			public FormRegisterFilterBuilder Field(int fieldId)
			{
				_currentFieldId = fieldId;
				_byId = true;
				return this;
			}

			public FormRegisterFilterBuilder Field(string fieldName)
			{
				_currentFieldName = fieldName;
				_byId = false;
				return this;
			}

			public FormRegisterFilterBuilder EqualsTo(object value)
			{
				switch (_byId)
				{
					case true:
						_formRegisterRequestBuilder._formRegisterRequest.Filters.Add(new EqualsFilter(_currentFieldId, value));
						break;
					case false:
						_formRegisterRequestBuilder._formRegisterRequest.Filters.Add(new EqualsFilter(_currentFieldName, value));
						break;
					case null:
						throw new ArgumentException("Field name or id should be set first");
				}

				_byId = null;
				return this;
			}

			public FormRegisterFilterBuilder LessThen(object value)
			{
				switch (_byId)
				{
					case true:
						_formRegisterRequestBuilder._formRegisterRequest.Filters.Add(new LessThanFilter(_currentFieldId, value));
						break;
					case false:
						_formRegisterRequestBuilder._formRegisterRequest.Filters.Add(new LessThanFilter(_currentFieldName, value));
						break;
					case null:
						throw new ArgumentException("Field name or id should be set first");
				}

				_byId = null;
				return this;
			}

			public FormRegisterFilterBuilder GreaterThen(object value)
			{
				switch (_byId)
				{
					case true:
						_formRegisterRequestBuilder._formRegisterRequest.Filters.Add(new GreaterThanFilter(_currentFieldId, value));
						break;
					case false:
						_formRegisterRequestBuilder._formRegisterRequest.Filters.Add(new GreaterThanFilter(_currentFieldName, value));
						break;
					case null:
						throw new ArgumentException("Field name or id should be set first");
				}

				_byId = null;
				return this;
			}

			public FormRegisterFilterBuilder IsInList(IEnumerable<object> values)
			{
				switch (_byId)
				{
					case true:
						_formRegisterRequestBuilder._formRegisterRequest.Filters.Add(new IsInFilter(_currentFieldId, values));
						break;
					case false:
						_formRegisterRequestBuilder._formRegisterRequest.Filters.Add(new IsInFilter(_currentFieldName, values));
						break;
					case null:
						throw new ArgumentException("Field name or id should be set first");
				}

				_byId = null;
				return this;
			}

			public FormRegisterFilterBuilder IsInList(params object[] values)
			{
				return IsInList((IEnumerable<object>)values);
			}

			public FormRegisterFilterBuilder Between(object start, object end)
			{
				switch (_byId)
				{
					case true:
						_formRegisterRequestBuilder._formRegisterRequest.Filters.Add(new RangeFilter(_currentFieldId, start, end));
						break;
					case false:
						_formRegisterRequestBuilder._formRegisterRequest.Filters.Add(new RangeFilter(_currentFieldName, start, end));
						break;
					case null:
						throw new ArgumentException("Field name or id should be set first");
				}

				_byId = null;
				return this;
			}

			public FormRegisterRequestBuilder BuildFilters()
			{
				return _formRegisterRequestBuilder;
			}
		}

	}
}
