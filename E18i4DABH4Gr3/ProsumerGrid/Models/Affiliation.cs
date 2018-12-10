using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProsumerGrid.Models
{
    public class Affiliation
    {
        [Key]
        public int AffiliationId { get; set; }
        [Required]
        public int MemberId { get; set; }
        public Member Member { get; set; }
        [Required]
        public int ProsumerId { get; set; }
        public Prosumer Prosumer { get; set; }
    }
}