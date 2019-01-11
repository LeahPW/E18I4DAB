using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProsumerGrid.Models.SmartGrid
{
    public class SmartGridViewModel
    {
        public List<NodeDTO> Nodes { get; set; }
        public GridDTO Grid { get; set; }
    }
}