using E18i4DABH4Gr3.Models;
using E18i4DABH4Gr3.Repositories;
using E18iDABH4Gr3.Repositories;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace ProsumerGrid.Controllers.TradeApi
{
    //[Produces("application/json")]
    //[Route("api/Trade")]
    //[ApiController]
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

        [Route("api/Trade/all")]
        [HttpGet]
        public IEnumerable<Trade> GetAll()
        {
            return _repository.Query().ToList();
        }

        [Route("api/Trade/planned")]
        [HttpGet]
        public IEnumerable<Trade> GetPlaned()
        {
            return _repository.Query().Where(t => (TradeStatus)t.Status == TradeStatus.Planned).ToList(); //casting due no time to refactoring
        }

        [Route("api/Trade/current")]
        [HttpGet]
        public IEnumerable<Trade> GetCurrent()
        {
            return _repository.Query().Where(t => (TradeStatus)t.Status == TradeStatus.Current).ToList(); //casting due no time to refactoring
        }

        [Route("api/Trade/archived")]
        [HttpGet]
        public IEnumerable<Trade> GetArchived()
        {
            return _repository.Query().Where(t => (TradeStatus)t.Status == TradeStatus.Archived).ToList(); //casting due no time to refactoring
        }
        public async Task<bool> Post(Trade trade) //would be nicer to return http status or a string about the success to connect to the database
        {
            return await _repository.Create(trade);
        }

        public async Task Put(string id, [FromBody] Trade trade)
        {
            await _repository.Update(id, trade);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }
    }

    public enum TradeStatus // should replace the int
    {
        Planned = 0,
        Current = 1,
        Archived = 2
    }
}