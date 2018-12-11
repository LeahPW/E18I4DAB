using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProsumerGrid.Models
{
    public class ProductionItemDTO
    {
        public int ProItemId { get; set; }
        public string Name { get; set; }
        public string ProsumerType { get; set; }
        
        public string ProsumerAddress { get; set; }
    }
}