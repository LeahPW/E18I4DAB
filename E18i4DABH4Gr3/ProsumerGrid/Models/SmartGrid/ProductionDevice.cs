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
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Production { get; set; }

        //Node
        [Required]
        public int NodeId { get; set; }
        public Node Node { get; set; }
    }
}