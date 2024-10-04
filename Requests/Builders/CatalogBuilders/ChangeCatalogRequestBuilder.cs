#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;

namespace PyrusApiClient.Builders
{
    /// <summary>
    /// Builder for <see cref="UpdateCatalogItemsRequest"/> to change catalog items.
    /// </summary>
    public class ChangeCatalogRequestBuilder
    {
        private readonly UpdateCatalogItemsRequest _request;
        
        /// <summary>
        /// ID of a catalog.
        /// </summary>
        public int CatalogId { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="ChangeCatalogRequestBuilder"/> class.
        /// </summary>
        /// <param name="catalogId">ID of a catalog.</param>
        public ChangeCatalogRequestBuilder(int catalogId)
        {
            _request = new UpdateCatalogItemsRequest
            {
                UpsertItems = new List<CatalogItem>(),
                DeleteItems = new HashSet<string>(),
            };
            CatalogId = catalogId;
        }

        public static implicit operator UpdateCatalogItemsRequest(ChangeCatalogRequestBuilder builder)
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
        /// <returns>The same instance of the <see cref="ChangeCatalogRequestBuilder"/> for chaining.</returns>
        public ChangeCatalogRequestBuilder UpsertItem(CatalogItem item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            return UpsertItem(item.Values);
        }

        /// <summary>
        /// Adds values of a catalog item to be inserted or updated.
        /// </summary>
        /// <param name="values">Collection of values.</param>
        /// <returns>The same instance of the <see cref="ChangeCatalogRequestBuilder"/> for chaining.</returns>
        public ChangeCatalogRequestBuilder UpsertItem(IEnumerable<string> values)
        {
            if (values is null)
                throw new ArgumentNullException(nameof(values));

            if (_request.UpsertItems is null)
                throw new InvalidOperationException($"{nameof(_request.UpsertItems)} is null.");

            _request.UpsertItems.Add(new CatalogItem { Values = values.ToList() });

            return this;
        }

        /// <summary>
        /// Adds values of a catalog item to be inserted or updated.
        /// </summary>
        /// <param name="values">Collection of values.</param>
        /// <returns>The same instance of the <see cref="ChangeCatalogRequestBuilder"/> for chaining.</returns>
        public ChangeCatalogRequestBuilder UpsertItem(params string[] values) => UpsertItem((IEnumerable<string>)values);

        #endregion
        
        #region Upsert multiple items

        /// <summary>
        /// Adds catalog items to be inserted or updated.
        /// </summary>
        /// <param name="items">Collection of <see cref="CatalogItem"/>.</param>
        /// <returns>The same instance of the <see cref="ChangeCatalogRequestBuilder"/> for chaining.</returns>
        public ChangeCatalogRequestBuilder UpsertItems(IEnumerable<CatalogItem> items)
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
        /// <param name="items">Collection of <see cref="CatalogItem"/>.</param>
        /// <returns>The same instance of the <see cref="ChangeCatalogRequestBuilder"/> for chaining.</returns>
        public ChangeCatalogRequestBuilder UpsertItems(params CatalogItem[] items) => UpsertItems((IEnumerable<CatalogItem>)items);

        #endregion
        
        #region Delete a single item
        
        /// <summary>
        /// Adds a catalog item to be deleted.
        /// </summary>
        /// <param name="item">Catalog item.</param>
        /// <returns>The same instance of the <see cref="ChangeCatalogRequestBuilder"/> for chaining.</returns>
        public ChangeCatalogRequestBuilder DeleteItem(CatalogItem item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (item.Values is null || item.Values.Count == 0)
                throw new ArgumentException("Catalog item Values is null or empty.", nameof(item));
                
            return DeleteItem(item.Values.First());
        }

        /// <summary>
        /// Adds a key of a catalog item to be deleted.
        /// </summary>
        /// <param name="key">Catalog item key (a value of the first column).</param>
        /// <returns>The same instance of the <see cref="ChangeCatalogRequestBuilder"/> for chaining.</returns>
        public ChangeCatalogRequestBuilder DeleteItem(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));
        
            if (_request.DeleteItems is null)
                throw new InvalidOperationException($"{nameof(_request.DeleteItems)} is null.");

            if (!_request.DeleteItems.Add(key))
                throw new ArgumentException("Trying to add a duplicate key for deletion.", nameof(key));
                
            return this;
        } 

        #endregion
        
        #region Delete multiple items

        /// <summary>
        /// Adds catalog items to be deleted.
        /// </summary>
        /// <param name="items">Collection of <see cref="CatalogItem"/>.</param>
        /// <returns>The same instance of the <see cref="ChangeCatalogRequestBuilder"/> for chaining.</returns>
        public ChangeCatalogRequestBuilder DeleteItems(IEnumerable<CatalogItem> items)
        {
            if (items is null) 
                throw new ArgumentNullException(nameof(items));
                
            foreach (var item in items)
                DeleteItem(item);

            return this;
        } 

        /// <summary>
        /// Adds catalog items to be deleted.
        /// </summary>
        /// <param name="items">Collection of <see cref="CatalogItem"/>.</param>
        /// <returns>The same instance of the <see cref="ChangeCatalogRequestBuilder"/> for chaining.</returns>
        public ChangeCatalogRequestBuilder DeleteItems(params CatalogItem[] items) => DeleteItems((IEnumerable<CatalogItem>)items);
        
        /// <summary>
        /// Adds catalog item keys to be deleted.
        /// </summary>
        /// <param name="keys">Collection of catalog item keys (values of the first column).</param>
        /// <returns>The same instance of the <see cref="ChangeCatalogRequestBuilder"/> for chaining.</returns>
        public ChangeCatalogRequestBuilder DeleteItems(IEnumerable<string> keys)
        {
            if (keys is null) 
                throw new ArgumentNullException(nameof(keys));
                
            foreach (var key in keys)
                DeleteItem(key);
                
            return this;
        }

        /// <summary>
        /// Adds catalog item keys to be deleted.
        /// </summary>
        /// <param name="keys">Collection of catalog item keys (values of the first column).</param>
        /// <returns>The same instance of the <see cref="ChangeCatalogRequestBuilder"/> for chaining.</returns>
        public ChangeCatalogRequestBuilder DeleteItems(params string[] keys) => DeleteItems((IEnumerable<string>)keys);

        #endregion
    }
}

#nullable disable
