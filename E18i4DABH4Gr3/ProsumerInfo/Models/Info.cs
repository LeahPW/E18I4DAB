using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProsumerInfo.Models
{
    public class Info
    {
        [Key]
        public int ProsumerId { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Name { get; set; }
    }
}