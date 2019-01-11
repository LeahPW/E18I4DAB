using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProsumerGrid.Models.Prosumer
{
    public class ProsumerDTO
    {
        public int ProsumerId { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public double Prosumption { get; set; }
        public string SmartMeterIp { get; set; }
        public string SmartMeterName { get; set; }
        public double SmartMeterBalance { get; set; }
    }
}