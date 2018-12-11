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
        //Foreign key
        [Required]
        public int MemberId { get; set; }
        //Navigation property
        public Member Member { get; set; }
        //Foreign key
        [Required]
        public int ProsumerId { get; set; }
        //Navigation property
        public Prosumer Prosumer { get; set; }
    }
}