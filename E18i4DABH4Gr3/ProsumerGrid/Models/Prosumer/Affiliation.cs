using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProsumerGrid.Models.Prosumer
{
    public class Affiliation
    {
        [Key]
        public int Id { get; set; }

        //Member
        [Required]
        public int MemberId { get; set; }
        public Member Member { get; set; }

        //Prosumer
        [Required]
        public int ProsumerId { get; set; }
        public ProsumerInfo ProsumerInfo { get; set; }
    }
}