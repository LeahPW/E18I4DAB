using E18i4DABH4Gr3.Models;
using E18i4DABH4Gr3.Repositories;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ProsumerGrid.Controllers.Document
{
    public class TradeController : ApiController
    {
        // cosmos connection layer
        private const string _endpointUrl = "https://localhost:8081";
        private const string _primaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        private const string _databaseId = "TradeDB";
        private const string _collectionId = "TradeCollection";
        private static DocumentClient _client; // keep alive
        private TradeRepository _repository;

        public TradeController()
        {          
            var databaseUri = UriFactory.CreateDatabaseUri(_databaseId);
            _client = new DocumentClient(new Uri(_endpointUrl), _primaryKey);
            _client.CreateDatabaseIfNotExistsAsync(new Database() { Id = _databaseId });
            _client.CreateDocumentCollectionIfNotExistsAsync(databaseUri, new DocumentCollection{Id = _collectionId}).Wait();
            _repository = new TradeRepository(_client, _databaseId, _collectionId);
        }

        public async Task<Trade> Get(string id)
        {
            return await _repository.Read(id);
        }

        public async Task Post([FromBody]Trade trade)
        {
            await _repository.Create(trade);
        }

        public async Task Post([FromBody]List<Trade> trades)
        {
            foreach (Trade t in trades)
            {
                await _repository.Create(t);
            }
        }

        public async Task Put(string id, [FromBody] Trade trade)
        {
            await _repository.Update(id, trade);
        }
    }
}