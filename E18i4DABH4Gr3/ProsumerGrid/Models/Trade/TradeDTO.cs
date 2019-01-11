using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProsumerGrid.Models.Trade
{
    public class TradeDTO
    {
        public string Id { get; set; }
        public double Prosumed { get; set; }
        public double MonetaryValue { get; set; }
        public int Status { get; set; }
        public DateTime TradeTime { get; set; }
        public int ProsumerId { get; set; }
    }
}