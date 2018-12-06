using ProsumerInfo.Models;

namespace ProsumerInfo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProsumerInfo.Models.ProsumerInfoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProsumerInfo.Models.ProsumerInfoContext context)
        {
            //context.Authors.AddOrUpdate(x => x.Id,
            //    new Author() { Id = 1, Name = "Jane Austen" },
            //    new Author() { Id = 2, Name = "Charles Dickens" },
            //    new Author() { Id = 3, Name = "Miguel de Cervantes" }
            //);
            context.Infoes.AddOrUpdate(x => x.ProsumerId,
                new Info(){ProsumerId = 1, Type = "Company", Address = "Street 69", Name = "Com"},
                new Info() { ProsumerId = 2, Type = "Household", Address = "Road 420", Name = "Richard Butt" }
                );

            context.Prosumptions.AddOrUpdate(x => x.ProsumptionId,
                new Prosumption() { ProsumptionId = 1, Consumption = 66.6, Production = 0, Balance = 0, ProsumerId = 2, SmartMeter = "smartmeterstring2000"}
            );

        }
    }
}
