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
        [Key]
        public int TradeId { get; set; }
        [Required]
        public bool Produce { get; set; }
        [Required]
        //Måles i kWh
        public double Prosumed { get; set; }
        [Required]
        //Omregnes fra kWh til kroner
        public double MonetaryValue { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public DateTime TradeTime { get; set; }
        [Required]
        public int ProsumerId { get; set; }
        public string Id { get; internal set; }
    }
}