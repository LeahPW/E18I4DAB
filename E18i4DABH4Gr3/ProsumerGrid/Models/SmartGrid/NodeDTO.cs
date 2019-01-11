using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProsumerGrid.Models.SmartGrid
{
    public class NodeDTO
    {
        public int Id { get; set; }

        public double Production { get; set; }
        public double Consumption { get; set; }
        public double Balance { get; set; }

        public int ProsumerInfoId { get; set; }

        
        public string GridName { get; set; }
        public double GridBalance { get; set; }
        public double GridBlockExchangeValue { get; set; }
    }
}