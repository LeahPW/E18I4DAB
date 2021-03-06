﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProsumerGrid.Models.SmartGrid
{
    public class GridDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Production { get; set; }
        public double Consumption { get; set; }
        public double Balance { get; set; }

        public int Term { get; set; }
        public double BlockExchangeValue { get; set; }
    }
}