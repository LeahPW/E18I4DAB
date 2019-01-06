using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using SmartGrid.Models;
using SmartGrid.Repositories;

namespace ProsumerGrid.Controllers
{
    public class TradeInfoController : ApiController
    {
        private const string _endpointUrl = "https://localhost:8081";
        private const string _primaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        private readonly DocumentClient _client;

        private TradeRepository _repository;

        public TradeInfoController()
        {
            _client = new DocumentClient(new Uri(_endpointUrl), _primaryKey);
            _client.CreateDatabaseIfNotExistsAsync(new Database() { Id = "TradeDB" }).Wait(2000);
            _client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("TradeDB"),
                new DocumentCollection { Id = "TradeCollection" }).Wait(2000);

            _repository = new TransactionRepository(_client, "TransactionDB", "TransactionCollection");
        }

        // GET: api/Trade
        public async Task<IEnumerable<Trade>> Get()
        {
            return await _repository.ReadAll();
        }

        // GET: api/Trade/5
        public async Task<Trade> Get(string id)
        {
            return await _repository.Read(id);
        }

        // POST: api/Trade
        public async Task Post([FromBody]Trade t)
        {
            await _repository.Create(t);
        }
        
        // POST: api/Trade
        public async Task Post([FromBody]List<Trade> trades)
        {
            foreach (Transaction t in trades)
            {
                await _repository.Create(t);
            }
        }
    }
}
