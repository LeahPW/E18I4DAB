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

        //Prosumer Info Db


        public System.Data.Entity.DbSet<ProsumerGrid.Models.Prosumer.ProsumerInfo> Prosumers { get; set; }

        public System.Data.Entity.DbSet<ProsumerGrid.Models.Prosumer.Member> Members { get; set; }


        public System.Data.Entity.DbSet<ProsumerGrid.Models.Prosumer.Affiliation> Affiliations { get; set; }

        //Smart Grid Info Db
        public System.Data.Entity.DbSet<ProsumerGrid.Models.SmartGrid.ProductionDevice> ProductionDevices { get; set; }
        public System.Data.Entity.DbSet<ProsumerGrid.Models.SmartGrid.ConsumptionDevice> ConsumptionDevices { get; set; }
        public System.Data.Entity.DbSet<ProsumerGrid.Models.SmartGrid.SmartMeter> SmartMeters { get; set; }
        public System.Data.Entity.DbSet<ProsumerGrid.Models.SmartGrid.Grid> Grid { get; set; }

        public System.Data.Entity.DbSet<ProsumerGrid.Models.SmartGrid.Node> Nodes { get; set; }

        public System.Data.Entity.DbSet<E18i4DABH4Gr3.Models.Trade> Trades { get; set; }

        public System.Data.Entity.DbSet<ProsumerGrid.Models.Trade.TradeDTO> TradeDTOes { get; set; }
    }
}
