using E18iDABH4Gr3;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E18i4DABH4Gr3.Models
{
    public class Trade
    {
        public string Id { get; set; }
        public bool Produce { get; set; }
        public double Prosumed { get; set; }
        //Omregnes fra kWh til kroner
        public double MonetaryValue { get; set; }
        public int Status { get; set; }
        public DateTime TradeTime { get; set; }
        public int ProsumerId { get; set; }

    }
}