using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProsumerGrid.Models.SmartGrid
{
    public class ProductionDevice
    {
        [Key]
        public int ProDeviceId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Production { get; set; }
        //Foreign key
        [Required]
        public int ProsumerId { get; set; }
        //Navigation property
        public Prosumer.Prosumer Prosumer { get; set; }
    }
}