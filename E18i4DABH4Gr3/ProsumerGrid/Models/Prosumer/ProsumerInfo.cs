using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProsumerGrid.Models.SmartGrid;

namespace ProsumerGrid.Models.Prosumer
{
    public class ProsumerInfo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Address { get; set; }

        //public virtual ICollection<Member> Members { get; set; }
        //public ICollection<ConsumptionDevice> ConItems { get; set; }
        //public ICollection<ProductionDevice> ProItems { get; set; }
    }
}