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
        private const string _endpointUrl = "https://localhost:8081";
        private const string _key = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        private const string _databaseId = "TradeDB";
        private const string _collectionId = "TradeCollection";


        private readonly DocumentClient _client;
        private TradeRepository _repository;

        public TradeController()
        {
            _client = new DocumentClient(new Uri(_endpointUrl), _key);
            _client.CreateDatabaseIfNotExistsAsync(new Database() { Id = _databaseId });
            _repository = new TradeRepository(_client, _databaseId, _collectionId);
        }

        public async Task Post([FromBody]Trade trade)
        {
            await _repository.Create(trade);
        }

    }
}