using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProsumerGrid.Models.SmartGrid
{
    public class ConsumptionDeviceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Consumption { get; set; }
    }
}