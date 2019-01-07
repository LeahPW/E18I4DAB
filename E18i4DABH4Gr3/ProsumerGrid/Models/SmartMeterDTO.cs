using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProsumerGrid.Models
{
    public class SmartMeterDTO
    {
        public string IpAddress { get; set; }
        public string Name { get; set; }
        public string Production { get; set; }
        public string Comsumption { get; set; }
    }
}