using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProsumerGrid.Models
{
    public class ConsumptionItemDTO
    {
        public int ConItemId { get; set; }
        public string Name { get; set; }
        public string ProsumerType { get; set; }

        public string ProsumerAddress { get; set; }
    }
}