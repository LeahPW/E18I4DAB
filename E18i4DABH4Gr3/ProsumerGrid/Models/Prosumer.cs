using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProsumerGrid.Models
{
    public class Prosumer
    {
        [Key]
        public int ProsumerId { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int SmartMeterId { get; set; }
        public SmartMeter SmartMeter { get; set; }

        //public ICollection<Member> Members { get; set; }
        //public ICollection<ConsumptionItem> ConItems { get; set; }
        //public ICollection<ProductionItem> ProItems { get; set; }
    }
}