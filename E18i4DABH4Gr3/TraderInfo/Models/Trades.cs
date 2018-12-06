using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TraderInfo.Models
{
    public class Trades
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
    }
}