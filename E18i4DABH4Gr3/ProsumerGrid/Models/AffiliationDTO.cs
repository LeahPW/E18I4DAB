using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProsumerGrid.Models
{
    public class AffiliationDTO
    {
        public int AffiliationId { get; set; }
        public string MemberName { get; set; }
        public string ProsumerAddress { get; set; }
        public string SmartMeterIp { get; set; }
    }
}