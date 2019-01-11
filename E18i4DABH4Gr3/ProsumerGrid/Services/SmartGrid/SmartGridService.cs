using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}