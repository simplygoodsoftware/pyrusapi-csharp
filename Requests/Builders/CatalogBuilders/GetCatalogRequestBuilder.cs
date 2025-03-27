using System;
using System.Collections.Generic;
using Pyrus.ApiClient.Entities;

namespace PyrusApiClient.Builders
{
	public class GetCatalogRequestBuilder
	{
		public bool IncludeDeletedItems { get; private set; }
		public int CatalogId { get; }

		public GetCatalogRequestBuilder(int catalogId)
		{
			CatalogId = catalogId;
			_filters = new List<CatalogItemValueFilter>();
		}

		public GetCatalogRequestBuilder IncludeDeleted()
		{
			if (_filters.Count > 0)
				throw new InvalidOperationException("Filtering deleted items is not supported.");

			IncludeDeletedItems = true;
			return this;
		}

		public GetCatalogRequestBuilder AddValueFilter(string columnName, string value, bool isRegularExpression = false)
		{
			if (columnName == null)
				throw new ArgumentNullException(nameof(columnName));

			if (value == null)
				throw new ArgumentNullException(nameof(value));

			if (IncludeDeletedItems)
				throw new InvalidOperationException("Filtering deleted items is not suppported.");

			_filters.Add(new CatalogItemValueFilter() { ColumnName = columnName, Value = value, IsRegularExpression = isRegularExpression });
			return this;
		}

		private readonly List<CatalogItemValueFilter> _filters;
		public IReadOnlyCollection<CatalogItemValueFilter> Filters => _filters;
	}
}
