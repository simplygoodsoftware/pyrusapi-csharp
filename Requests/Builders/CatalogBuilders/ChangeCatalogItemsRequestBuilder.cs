#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;

namespace PyrusApiClient.Builders
{
    /// <summary>
    /// Builder for a <see cref="PartialUpdateCatalogRequest"/> to change catalog items.
    /// </summary>
    public class ChangeCatalogItemsRequestBuilder
    {
        private readonly PartialUpdateCatalogRequest _request;
        
        /// <summary>
        /// ID of the catalog.
        /// </summary>
        public int CatalogId { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeCatalogItemsRequestBuilder"/> class.
        /// </summary>
        /// <param name="catalogId">ID of the catalog.</param>
        public ChangeCatalogItemsRequestBuilder(int catalogId)
        {
            _request = new PartialUpdateCatalogRequest
            {
                UpsertItems = new List<CatalogItem>(),
                DeleteItems = new HashSet<string>(),
            };
            CatalogId = catalogId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeCatalogItemsRequestBuilder"/> class.
        /// </summary>
        /// <param name="request">The <see cref="PartialUpdateCatalogRequest"/> containing catalog items to be changed.</param>
        /// <param name="catalogId">ID of the catalog.</param>
        public ChangeCatalogItemsRequestBuilder(PartialUpdateCatalogRequest request, int catalogId)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));
                
            var isEmptyUpsert = request.UpsertItems is null || request.UpsertItems.Count == 0;
            var isEmptyDelete = request.DeleteItems is null || request.DeleteItems.Count == 0;
            if (isEmptyUpsert && isEmptyDelete)
                throw new ArgumentException("Both UpsertItems and DeleteItems cannot be empty.", nameof(request));

            _request = request;
            CatalogId = catalogId;
        }

        public static implicit operator PartialUpdateCatalogRequest(ChangeCatalogItemsRequestBuilder builder)
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return builder._request;
        }

        #region Upsert a single item
        
        /// <summary>
        /// Adds a catalog item to be inserted or updated.
        /// </summary>
        /// <param name="item">Catalog item.</param>
        /// <returns>The same instance of the <see cref="ChangeCatalogItemsRequestBuilder"/> for chaining.</returns>
        public ChangeCatalogItemsRequestBuilder UpsertItem(CatalogItem item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            return UpsertItem(item.Values);
        }

        /// <summary>
        /// Adds values of a catalog item to be inserted or updated.
        /// </summary>
        /// <param name="values">Collection of values.</param>
        /// <returns>The same instance of the <see cref="ChangeCatalogItemsRequestBuilder"/> for chaining.</returns>
        public ChangeCatalogItemsRequestBuilder UpsertItem(IEnumerable<string> values)
        {
            if (values is null)
                throw new ArgumentNullException(nameof(values));

            _request.UpsertItems!.Add(new CatalogItem { Values = values.ToList() });

            return this;
        }

        /// <summary>
        /// Adds values of a catalog item to be inserted or updated.
        /// </summary>
        /// <param name="values">Collection of values.</param>
        /// <returns>The same instance of the <see cref="ChangeCatalogItemsRequestBuilder"/> for chaining.</returns>
        public ChangeCatalogItemsRequestBuilder UpsertItem(params string[] values) => UpsertItem((IEnumerable<string>)values);

        #endregion
        
        #region Upsert multiple items

        /// <summary>
        /// Adds catalog items to be inserted or updated.
        /// </summary>
        /// <param name="items">Collection of a <see cref="CatalogItem"/>.</param>
        /// <returns>The same instance of the <see cref="ChangeCatalogItemsRequestBuilder"/> for chaining.</returns>
        public ChangeCatalogItemsRequestBuilder UpsertItems(IEnumerable<CatalogItem> items)
        {
            if (items is null)
                throw new ArgumentNullException(nameof(items));

            foreach (var item in items)
                UpsertItem(item);

            return this;
        }
        
        /// <summary>
        /// Adds catalog items to be inserted or updated.
        /// </summary>
        /// <param name="items">Collection of a <see cref="CatalogItem"/>.</param>
        /// <returns>The same instance of the <see cref="ChangeCatalogItemsRequestBuilder"/> for chaining.</returns>
        public ChangeCatalogItemsRequestBuilder UpsertItems(params CatalogItem[] items) => UpsertItems((IEnumerable<CatalogItem>)items);

        #endregion
        
        #region Delete a single item
        
        /// <summary>
        /// Adds a catalog item to be deleted.
        /// </summary>
        /// <param name="item">Catalog item.</param>
        /// <returns>The same instance of the <see cref="ChangeCatalogItemsRequestBuilder"/> for chaining.</returns>
        public ChangeCatalogItemsRequestBuilder DeleteItem(CatalogItem item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (item.Values is null)
                throw new ArgumentException("Catalog item Values is null.", nameof(item));
                
            return DeleteItem(item.Values.First());
        }

        /// <summary>
        /// Adds a key of a catalog item to be deleted.
        /// </summary>
        /// <param name="key">Catalog item key (a value of the first column).</param>
        /// <returns>The same instance of the <see cref="ChangeCatalogItemsRequestBuilder"/> for chaining.</returns>
        public ChangeCatalogItemsRequestBuilder DeleteItem(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));
        
            if (!_request.DeleteItems!.Add(key))
                throw new ArgumentException("Trying to add a duplicate key for deletion.", nameof(key));
                
            return this;
        } 

        #endregion
        
        #region Delete multiple items

        /// <summary>
        /// Adds
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public ChangeCatalogItemsRequestBuilder DeleteItems(IEnumerable<CatalogItem> items)
        {
            if (items is null) 
                throw new ArgumentNullException(nameof(items));
                
            foreach (var item in items)
                DeleteItem(item);

            return this;
        } 

        public ChangeCatalogItemsRequestBuilder DeleteItems(params CatalogItem[] items) => DeleteItems((IEnumerable<CatalogItem>)items);
        
        public ChangeCatalogItemsRequestBuilder DeleteItems(IEnumerable<string> keys)
        {
            if (keys is null) 
                throw new ArgumentNullException(nameof(keys));
                
            foreach (var key in keys)
                DeleteItem(key);
                
            return this;
        }

        public ChangeCatalogItemsRequestBuilder DeleteItems(params string[] keys) => DeleteItems((IEnumerable<string>)keys);

        #endregion
    }
}

#nullable disable
