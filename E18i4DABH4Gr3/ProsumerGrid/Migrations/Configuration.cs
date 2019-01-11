using ProsumerGrid.Models;
using ProsumerGrid.Models.Prosumer;
using ProsumerGrid.Models.SmartGrid;

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
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ProsumerGrid.Models.ProsumerGridContext context)
        {
            context.SmartMeters.AddOrUpdate(
                p => p.Id,
                new SmartMeter { Id = 1, IpAddress = "192.0.0.1" },
                new SmartMeter { Id = 2, IpAddress = "192.0.0.2" });

            context.Prosumers.AddOrUpdate(
                p => p.Id,
                new ProsumerInfo { Id = 1, Type = "Company", Address = "Finlandsgade 22" },
                new ProsumerInfo { Id = 2, Type = "Household", Address = "Tranekærvej 58" });

            context.Members.AddOrUpdate(
                p => p.Id,
                new Member { Id = 1, Name = "Valeria P. W." });

            context.Affiliations.AddOrUpdate(
                p => p.Id,
                new Affiliation { MemberId = 1, ProsumerId = 1 },
                new Affiliation { MemberId = 1, ProsumerId = 2 });

            context.Grid.AddOrUpdate(
                g => g.Id, 
                new Grid{ Id = 1, Term = 1, Balance = 0, BlockExchangeValue = 1, Name = "Village Smart Grid" });

            context.Nodes.AddOrUpdate(
                p => p.Id,
                new Node { Id = 1, Production = 0, Consumption = 450, Balance = -450, SmartMeterId = 1, ProsumerInfoId = 1, Name = "Node 1", GridId = 1},
                new Node { Id = 2, Production = 150000, Consumption = 100000, Balance = 50000, SmartMeterId = 2, ProsumerInfoId = 2, Name = "Node 2", GridId = 1 }
                );

            context.ConsumptionDevices.AddOrUpdate(
                p=> p.Id,
                new ConsumptionDevice{Id = 1, Consumption = 300, Name = "Microwave", NodeId = 1},
                new ConsumptionDevice { Id = 1, Consumption = 150, Name = "Kettle", NodeId = 1 }
                );

            context.ProductionDevices.AddOrUpdate(
                p => p.Id,
                new ProductionDevice { Id = 1, Production = 150000, Name = "Power Generator", NodeId = 2 }
            );

        }
    }
}
