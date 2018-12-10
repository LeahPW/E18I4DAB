using ProsumerGrid.Models;

namespace ProsumerGrid.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProsumerGrid.Models.ProsumerGridContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProsumerGrid.Models.ProsumerGridContext context)
        {
            context.SmartMeters.AddOrUpdate(
                p=> p.SmartMeterId,
                new SmartMeter{SmartMeterId = 1, IpAddress = "192.0.0.1"},
                new SmartMeter{SmartMeterId = 2, IpAddress = "192.0.0.2"});

            context.Prosumers.AddOrUpdate(
                p => p.ProsumerId,
                new Prosumer{ProsumerId = 1, Type = "Company", SmartMeterId = 1, Address = "Finlandsgade 22"},
                new Prosumer{ProsumerId = 2, Type = "Household", SmartMeterId = 2, Address = "Tranekærvej 58"});

            context.Members.AddOrUpdate(
                p => p.MemberId,
                new Member { MemberId = 1, Name = "Valeria P. W."});

            context.Affiliations.AddOrUpdate(
                p => p.AffiliationId,
                new Affiliation{MemberId = 1, ProsumerId = 1},
                new Affiliation{MemberId = 1, ProsumerId = 2});
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
