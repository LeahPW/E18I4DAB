using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProsumerGrid.Models.SmartGrid
{
    public class Grid
    {
        [Key]
        public int GridId { get; set; }

        public string Name { get; set; }
        public double Balance { get; set; }
        public double BlockExchangeValue { get; set; }
    }
}