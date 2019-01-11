using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using ProsumerGrid.Models.Prosumer;
using ProsumerGrid.Models.SmartGrid;

namespace ProsumerGrid.Services.SmartGrid
{
    public class SmartGridService
    {
        private ApiClient<Grid, Grid> _gridApi;
        private ApiClient<Node, NodeDTO> _nodeApi;

        public SmartGridService()
        {
            _gridApi = new ApiClient<Grid, Grid>();
            _nodeApi = new ApiClient<Node, NodeDTO>();
        }


        public List<NodeDTO> GetNodeList()
        {
            List<Node> nodes = new List<Node>();
            try
            {
                HttpResponseMessage response = _nodeApi.GetResponse("Nodes");
                response.EnsureSuccessStatusCode();
                nodes = response.Content.ReadAsAsync<List<Node>>().Result;

            }
            catch (Exception)
            {
                throw;
            }

            var nodedtos = new List<NodeDTO>();
            var grid = GetGrid();
            nodes.ForEach(n => nodedtos.Add(NodeToDTO(n, grid)));

            return nodedtos;
        }

        private NodeDTO NodeToDTO(Node n, Grid g)
        {
            var result = new NodeDTO
            {
                Id = n.Id,
                ProsumerInfoId = n.ProsumerInfoId,
                Balance = n.Balance,
                GridName = g.Name,
                GridBalance = g.Balance,
                GridBlockExchangeValue = g.BlockExchangeValue,
                Consumption = n.Consumption,
                Production = n.Production
            };
            return result;
        }

        public bool UpdateTerm()
        {
            IncrementTerm();

            List<Node> nodes;
            try
            {
                HttpResponseMessage response = _nodeApi.GetResponse("Node");
                response.EnsureSuccessStatusCode();
                nodes = response.Content.ReadAsAsync<List<Node>>().Result;
            }
            catch (Exception)
            {
                throw;
            }

            foreach (var node in nodes)
            {




            }


            return true;
        }

        private List<ConsumptionDevice> GetNodeConDevices(int id)
        {
            List<ConsumptionDevice> devices;
            try
            {
                HttpResponseMessage response = _nodeApi.GetResponse("ConsumptionItem");
                response.EnsureSuccessStatusCode();
                devices = response.Content.ReadAsAsync<List<ConsumptionDevice>>().Result;
            }
            catch (Exception)
            {
                throw;
            }

            return devices.Where(d => d.NodeId == id).ToList();
        }

        private List<ProductionDevice> GetNodeProDevices(int id)
        {
            List<ProductionDevice> devices;
            try
            {
                HttpResponseMessage response = _nodeApi.GetResponse("ProductionItem");
                response.EnsureSuccessStatusCode();
                devices = response.Content.ReadAsAsync<List<ProductionDevice>>().Result;
            }
            catch (Exception)
            {
                throw;
            }

            return devices.Where(d => d.NodeId == id).ToList();
        }

        public Grid GetGrid()
        {
            Grid grid;
            try
            {
                HttpResponseMessage response = _gridApi.GetResponse("Grid");
                response.EnsureSuccessStatusCode();
                grid = response.Content.ReadAsAsync<List<Grid>>().Result.First();
            }
            catch (Exception)
            {
                throw;
            }

            return grid;
        }
        private void IncrementTerm()
        {

            var grid = GetGrid();

            grid.Term++;

            try
            {
                HttpResponseMessage response = _gridApi.Put("Grid", grid);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}