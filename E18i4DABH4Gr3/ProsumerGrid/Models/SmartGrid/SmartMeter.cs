﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProsumerGrid.Models.SmartGrid
{
    public class SmartMeter
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string IpAddress { get; set; }
        public string Name { get; set; }
    }
}