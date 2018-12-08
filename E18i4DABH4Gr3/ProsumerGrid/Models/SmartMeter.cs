using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProsumerGrid.Models
{
    public class SmartMeter
    {
        [Key]
        public int SmartMeterId { get; set; }
        [Required]
        public string IpAddress { get; set; }
        public string Name { get; set; }
        [Required]
        public int ProsumerId { get; set; }
        public Prosumer Prosumer { get; set; }
    }
}