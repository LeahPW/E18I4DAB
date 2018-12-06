using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProsumerInfo.Models
{
    public class Prosumption
    {
        [Key]
        public int ProsumptionId { get; set; }
        [Required]
        public double Production { get; set; }
        [Required]
        public double Consumption { get; set; }
        [Required]
        public double Balance { get; set; }
        [Required]
        public string SmartMeter { get; set; }

        [Required]
        public int ProsumerId { get; set; }
        public Info ProsumerInfo { get; set; }
    }
}