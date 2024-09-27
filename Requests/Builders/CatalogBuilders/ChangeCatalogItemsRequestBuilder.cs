using System.Collections.Generic;
using System.Linq;

namespace PyrusApiClient.Builders
{
    public class ChangeCatalogItemsRequestBuilder
    {
        private readonly PartialUpdateCatalogRequest _request;
        public int CatalogId { get; }

        public ChangeCatalogItemsRequestBuilder(int catalogId)
        {
            _request = new PartialUpdateCatalogRequest();
            CatalogId = catalogId;
        }

        public ChangeCatalogItemsRequestBuilder(PartialUpdateCatalogRequest request, int catalogId)
        {
            _request = request;
            CatalogId = catalogId;
        }

        public static implicit operator PartialUpdateCatalogRequest(ChangeCatalogItemsRequestBuilder builder)
        {
            return builder._request;
        }

        public ChangeCatalogItemsRequestBuilder UpsertItem(CatalogItem item)
        {
            _request.UpsertItems.Add(item);
            return this;
        }

        public ChangeCatalogItemsRequestBuilder UpsertItems(IEnumerable<CatalogItem> items)
        {
            _request.UpsertItems.AddRange(items);
            return this;
        }

        public ChangeCatalogItemsRequestBuilder UpsertItems(params CatalogItem[] items)
        {
            _request.UpsertItems.AddRange(items);
            return this;
        }

        public ChangeCatalogItemsRequestBuilder UpsertItem(IEnumerable<string> values)
        {
            _request.UpsertItems.Add(new CatalogItem { Values = values.ToList() });
            return this;
        }

        public ChangeCatalogItemsRequestBuilder UpsertItem(params string[] values)
        {
            _request.UpsertItems.Add(new CatalogItem { Values = values.ToList() });
            return this;
        }

        public ChangeCatalogItemsRequestBuilder DeleteItem(CatalogItem item)
        {
            _request.DeleteItems.Add(item.Values.First());
            return this;
        }
        
        public ChangeCatalogItemsRequestBuilder DeleteItems(IEnumerable<CatalogItem> items)
        {
            _request.DeleteItems.AddRange(items.Select(item => item.Values.First()));
            return this;
        } 
        
        public ChangeCatalogItemsRequestBuilder DeleteItem(params CatalogItem[] items)
        {
            _request.DeleteItems.AddRange(items.Select(item => item.Values.First()));
            return this;
        }
        
        public ChangeCatalogItemsRequestBuilder DeleteItem(string key)
        {
            _request.DeleteItems.Add(key);
            return this;
        } 
        
        public ChangeCatalogItemsRequestBuilder DeleteItems(IEnumerable<string> keys)
        {
            _request.DeleteItems.AddRange(keys);
            return this;
        } 
        
        public ChangeCatalogItemsRequestBuilder DeleteItem(params string[] keys)
        {
            _request.DeleteItems.AddRange(keys);
            return this;
        }
    }
}