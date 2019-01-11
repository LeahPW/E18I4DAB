using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProsumerGrid.Models.SmartGrid
{
    public class ProductionDeviceDTO
    {
        public int ProDeviceId { get; set; }
        public string Name { get; set; }
        public double Production { get; set; }
        public string ProsumerType { get; set; }
        
        public string ProsumerAddress { get; set; }
    }
}