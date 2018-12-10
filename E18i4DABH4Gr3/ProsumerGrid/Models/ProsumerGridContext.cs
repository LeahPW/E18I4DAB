using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProsumerGrid.Models
{
    public class ProsumerGridContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ProsumerGridContext() : base("name=ProsumerGridContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<ProsumerGrid.Models.ConsumptionItem> ConsumptionItems { get; set; }

        public System.Data.Entity.DbSet<ProsumerGrid.Models.Prosumer> Prosumers { get; set; }

        public System.Data.Entity.DbSet<ProsumerGrid.Models.Member> Members { get; set; }

        public System.Data.Entity.DbSet<ProsumerGrid.Models.ProductionItem> ProductionItems { get; set; }

        public System.Data.Entity.DbSet<ProsumerGrid.Models.SmartMeter> SmartMeters { get; set; }

        public System.Data.Entity.DbSet<ProsumerGrid.Models.Affiliation> Affiliations { get; set; }
    }
}
