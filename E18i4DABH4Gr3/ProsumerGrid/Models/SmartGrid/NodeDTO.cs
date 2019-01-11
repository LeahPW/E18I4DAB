using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProsumerGrid.Models.SmartGrid
{
    public class NodeDTO
    {
        public int NodeId { get; set; }
        public double NodeBalance { get; set; }

        public int ProsumerId { get; set; }
        //public string ProsumerType { get; set; }
        //public string ProsumerAddress { get; set; }

        public string GridName { get; set; }
        public double GridBalance { get; set; }
        public double GridBlockExchangeValue { get; set; }
    }
}