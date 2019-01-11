using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProsumerGrid.Models.Prosumer
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        //public virtual ICollection<ProsumerInfo> Prosumers { get; set; }

        // Med de to linje kan man skabe direkte forbindelse mellem ProsumerInfo og Member
        //Ligesom i Hanin 1 og 2, hvor en person skulle have en primær adresse
        //[Required]
        //public int Id { get; set; }
        //public ProsumerInfo ProsumerInfo { get; set; }
    }
}