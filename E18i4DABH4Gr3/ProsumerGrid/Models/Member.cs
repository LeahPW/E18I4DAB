using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProsumerGrid.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        [Required]
        public string Name { get; set; }

        //public virtual ICollection<Prosumer> Prosumers { get; set; }

        // Med de to linje kan man skabe direkte forbindelse mellem Prosumer og Member
        //Ligesom i Hanin 1 og 2, hvor en person skulle have en primær adresse
        //[Required]
        //public int ProsumerId { get; set; }
        //public Prosumer Prosumer { get; set; }
    }
}