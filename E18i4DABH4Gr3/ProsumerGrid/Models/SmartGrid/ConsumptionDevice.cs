using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProsumerGrid.Models.SmartGrid
{
    public class ConsumptionDevice
    {
        [Key]
        public int ConDeviceId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Consumption { get; set; }
        //Foreign key
        [Required]
        public int ProsumerId { get; set; }
        //Navigation property
        public Prosumer.Prosumer Prosumer { get; set; }
    }
}