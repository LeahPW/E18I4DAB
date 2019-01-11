using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProsumerGrid.Models.SmartGrid
{
    public class ConsumptionDeviceDTO
    {
        public int ConDeviceId { get; set; }
        public string Name { get; set; }
        public double Consumption { get; set; }
        public string ProsumerType { get; set; }

        public string ProsumerAddress { get; set; }
    }
}