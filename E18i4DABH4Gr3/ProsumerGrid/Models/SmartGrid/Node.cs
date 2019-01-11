using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProsumerGrid.Models.SmartGrid
{
    public class Node
    {
        [Key]
        public int NodeId { get; set; }


        public double Balance { get; set; }

        //Foreign key
        [Required]
        public int ProsumerId { get; set; }
        //Navigation property
        public Prosumer.Prosumer Prosumer { get; set; }


        //Foreign key
        [Required]
        public int GridId { get; set; }
        //Navigation property
        public Grid Grid { get; set; }

    }
}