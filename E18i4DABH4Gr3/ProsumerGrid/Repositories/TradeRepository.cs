﻿using E18iDABH4Gr3.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using E18i4DABH4Gr3.Models;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents;
using System.Net;
using System.Diagnostics;

namespace E18i4DABH4Gr3.Repositories
{
    public class TradeRepository : IRepository<Trade>
    {
        private readonly DocumentClient _client;
        private readonly string _databaseId;
        private readonly string _collectionId;

        public TradeRepository(DocumentClient client, string databaseId, string collectionId)
        {
            _client = client;
            _databaseId = databaseId;
            _collectionId = collectionId;
        }

        public async Task<bool> Create(Trade trade)
        {
            try
            {
                await _client.ReadDocumentAsync(UriFactory.CreateDocumentUri(_databaseId, _collectionId, trade.Id));
                return true;

            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                {
                    await _client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(_databaseId, _collectionId),
                        trade);
                    return true;
                }
                else
                {
                    Debug.WriteLine(e);
                    return false;
                }
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                await _client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(_databaseId, _collectionId, id));
                return true;
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                {
                    Debug.WriteLine(e);
                    Debug.WriteLine("Not found.");
                }
                else
                {
                    Debug.WriteLine(e);
                }
                return false;
            }
        }

        public IOrderedQueryable<Trade> Query()
        {
            FeedOptions queryOptions = new FeedOptions() { MaxItemCount = -1 };
            return _client.CreateDocumentQuery<Trade>(UriFactory.CreateDocumentCollectionUri(_databaseId, _collectionId), queryOptions);
        }
            
        public async Task<Trade> Read(string id)
        {
            try
            {
                var documentResponse = await _client.ReadDocumentAsync<Trade>(UriFactory.CreateDocumentUri(_databaseId, _collectionId, id));
                return documentResponse.Document;
            }
            catch (DocumentClientException e)
            {
                Debug.WriteLine(e);
                if (e.StatusCode == HttpStatusCode.NotFound)
                {
                    Debug.WriteLine("Not found.");
                }
                return null;
            }
        }

        public async Task<bool> Update(string id, Trade trade)
        {
            try
            {
                await _client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(_databaseId, _collectionId, trade.Id), trade);
                return true;
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                {
                    Debug.WriteLine(e);
                    Debug.WriteLine("Not found.");
                }
                else
                {
                    Debug.WriteLine(e);
                }
                return false;
            }
        }
    }
}