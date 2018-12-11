using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProsumerGrid.Models
{
    public class ProductionItem
    {
        [Key]
        public int ProItemId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Production { get; set; }
        //Foreign key
        [Required]
        public int ProsumerId { get; set; }
        //Navigation property
        public Prosumer Prosumer { get; set; }
    }
}