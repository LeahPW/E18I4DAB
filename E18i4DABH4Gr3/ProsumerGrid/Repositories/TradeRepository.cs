using E18iDABH4Gr3.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using E18i4DABH4Gr3.Models;
using Microsoft.Azure.Documents.Client;

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

        public Task Create(Trade t)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Trade t)
        {
            throw new NotImplementedException();
        }

        public Task<Trade> Read(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Trade>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public Task Update(int id, Trade t)
        {
            throw new NotImplementedException();
        }
    }
}