using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProsumerGrid.Models.Prosumer;

namespace ProsumerGrid.Models.SmartGrid
{
    public class Node
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public double Production { get; set; }
        public double Consumption { get; set; }
        public double Balance { get; set; }

        //Grid
        [Required]
        public int GridId { get; set; }
        public Grid Grid { get; set; }

        //Prosumer Info
        [Required]
        public int ProsumerInfoId { get; set; }
        public ProsumerInfo ProsumerInfo { get; set; }

        //SmartMeter
        [Required]
        public int SmartMeterId { get; set; }
        public SmartMeter SmartMeter { get; set; }

    }
}