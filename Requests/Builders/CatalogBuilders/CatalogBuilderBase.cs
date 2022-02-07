using System.Collections.Generic;
using System.Linq;

namespace PyrusApiClient.Builders
{
	public abstract class CatalogBuilderBase<T> where T : CatalogBuilderBase<T>
	{
		protected CatalogRequestBase Request;
		protected CatalogBuilderBase(CatalogRequestBase request)
		{
			Request = request;
		}

		public T SetHeaders(IEnumerable<string> headers)
		{
			Request.CatalogHeaders = headers.ToList();
			return (T)this;
		}

		public T SetHeaders(params string[] headers)
		{
			Request.CatalogHeaders = headers.ToList();
			return (T)this;
		}

		public T SetColumnSettings(IEnumerable<ColumnSettings> settings)
		{
			Request.ColumnSettings = settings.ToList();
			return (T)this;
		}

		public T SetColumnSettings(params ColumnSettings[] settings)
		{
			Request.ColumnSettings = settings.ToList();
			return (T)this;
		}

		public T AddHeader(string header)
		{
			Request.CatalogHeaders.Add(header);
			return (T)this;
		}

		public T AddItem(CatalogItem item)
		{
			Request.Items.Add(item);
			return (T)this;
		}

		public T AddItems(IEnumerable<CatalogItem> items)
		{
			Request.Items.AddRange(items);
			return (T)this;
		}

		public T AddItems(params CatalogItem[] items)
		{
			Request.Items.AddRange(items);
			return (T)this;
		}

		public T AddItem(IEnumerable<string> values)
		{
			Request.Items.Add(new CatalogItem{Values = values.ToList()});
			return (T)this;
		}

		public T AddItem(params string[] values)
		{
			Request.Items.Add(new CatalogItem { Values = values.ToList() });
			return (T)this;
		}

		public T AddItems(IEnumerable<IEnumerable<string>> items)
		{
			Request.Items.AddRange(items.Select(i => new CatalogItem{Values = i.ToList()}));
			return (T)this;
		}
		public T AddItems(params IEnumerable<string>[] items)
		{
			Request.Items.AddRange(items.Select(i => new CatalogItem { Values = i.ToList() }));
			return (T)this;
		}

		public T SetItems(IEnumerable<CatalogItem> items)
		{
			Request.Items = items.ToList();
			return (T)this;
		}

		public T SetItems(IEnumerable<IEnumerable<string>> items)
		{
			Request.Items = items.Select(i => new CatalogItem { Values = i.ToList() }).ToList();
			return (T)this;
		}
	}
}
