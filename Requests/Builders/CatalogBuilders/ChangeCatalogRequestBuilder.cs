using System.Collections.Generic;
using System.Linq;
using PyrusApiClient;

namespace Pyrus.ApiClient.Requests.Builders
{
    public class ChangeCatalogRequestBuilder
    {
        public int CatalogId { get; }
        private readonly ChangeCatalogRequest _request;

        public ChangeCatalogRequestBuilder(int catalogId)
        {
            CatalogId = catalogId;
            _request = new ChangeCatalogRequest();
        }

        #region add

        public ChangeCatalogRequestBuilder AddItem(IEnumerable<string> values) =>
            AddItemToCollection(_request.Added, new CatalogItem { Values = values.ToList() });

        public ChangeCatalogRequestBuilder AddItem(CatalogItem item) =>
            AddItemToCollection(_request.Added, item);

        public ChangeCatalogRequestBuilder AddItems(params IEnumerable<string>[] values) 
            => AddItemsToList(_request.Added, values.Select(v => new CatalogItem { Values = v.ToList() }));

        public ChangeCatalogRequestBuilder AddItems(IEnumerable<IEnumerable<string>> values)
            => AddItemsToList(_request.Added, values.Select(v => new CatalogItem { Values = v.ToList() }));

        public ChangeCatalogRequestBuilder AddItems(params CatalogItem[] items) 
            => AddItemsToList(_request.Added, items);

        public ChangeCatalogRequestBuilder AddItems(IEnumerable<CatalogItem> items)
            => AddItemsToList(_request.Added, items);

        #endregion

        #region update

        public ChangeCatalogRequestBuilder UpdateItem(long itemId, IEnumerable<string> values)
            => AddItemToCollection(_request.Updated, new CatalogItem { Id = itemId, Values = values.ToList() });

        public ChangeCatalogRequestBuilder UpdateItem(CatalogItem item)
            => AddItemToCollection(_request.Updated, item);

        public ChangeCatalogRequestBuilder UpdateItems(params CatalogItem[] items)
            => AddItemsToList(_request.Updated, items);

        public ChangeCatalogRequestBuilder UpdateItems(IEnumerable<CatalogItem> items)
            => AddItemsToList(_request.Updated, items);

        #endregion

        #region delete

        public ChangeCatalogRequestBuilder DeleteItem(CatalogItem item)
            => AddItemToCollection(_request.Deleted, item);

        public ChangeCatalogRequestBuilder DeleteItem(long id)
            => AddItemToCollection(_request.Deleted, new CatalogItem { Id = id });

        public ChangeCatalogRequestBuilder DeleteItems(params long[] ids)
            => AddItemsToList(_request.Deleted, ids.Select(id => new CatalogItem { Id = id }));

        public ChangeCatalogRequestBuilder DeleteItems(IEnumerable<long> ids)
            => AddItemsToList(_request.Deleted, ids.Select(id => new CatalogItem { Id = id }));

        public ChangeCatalogRequestBuilder DeleteItems(IEnumerable<CatalogItem> items)
            => AddItemsToList(_request.Deleted, items);

        public ChangeCatalogRequestBuilder DeleteItems(params CatalogItem[] items)
            => AddItemsToList(_request.Deleted, items);

        #endregion

        private ChangeCatalogRequestBuilder AddItemToCollection(ICollection<CatalogItem> collection, CatalogItem item)
        {
            collection.Add(item);
            return this;
        }

        private ChangeCatalogRequestBuilder AddItemsToList(List<CatalogItem> collection, IEnumerable<CatalogItem> items)
        {
            collection.AddRange(items);
            return this;
        }

        public static implicit operator ChangeCatalogRequest(ChangeCatalogRequestBuilder ccrb)
        {
            return ccrb._request;
        }
    }
}
