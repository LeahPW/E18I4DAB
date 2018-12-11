namespace ProsumerGrid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Affiliations",
                c => new
                {
                    AffiliationId = c.Int(nullable: false, identity: true),
                    MemberId = c.Int(nullable: false),
                    ProsumerId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.AffiliationId)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.Prosumers", t => t.ProsumerId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.ProsumerId);

            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MemberId);
            
            CreateTable(
                "dbo.Prosumers",
                c => new
                    {
                        ProsumerId = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        SmartMeterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProsumerId)
                .ForeignKey("dbo.SmartMeters", t => t.SmartMeterId, cascadeDelete: true)
                .Index(t => t.SmartMeterId);
            
            CreateTable(
                "dbo.SmartMeters",
                c => new
                    {
                        SmartMeterId = c.Int(nullable: false, identity: true),
                        IpAddress = c.String(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SmartMeterId);
            
            CreateTable(
                "dbo.ConsumptionItems",
                c => new
                    {
                        ConItemId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Consumption = c.Double(nullable: false),
                        ProsumerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConItemId)
                .ForeignKey("dbo.Prosumers", t => t.ProsumerId, cascadeDelete: true)
                .Index(t => t.ProsumerId);
            
            CreateTable(
                "dbo.ProductionItems",
                c => new
                    {
                        ProItemId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Production = c.Double(nullable: false),
                        ProsumerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProItemId)
                .ForeignKey("dbo.Prosumers", t => t.ProsumerId, cascadeDelete: true)
                .Index(t => t.ProsumerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductionItems", "ProsumerId", "dbo.Prosumers");
            DropForeignKey("dbo.ConsumptionItems", "ProsumerId", "dbo.Prosumers");
            //DropForeignKey("dbo.Affiliations", "ProsumerId", "dbo.Prosumers");
            DropForeignKey("dbo.Prosumers", "SmartMeterId", "dbo.SmartMeters");
            //DropForeignKey("dbo.Affiliations", "MemberId", "dbo.Members");
            DropIndex("dbo.ProductionItems", new[] { "ProsumerId" });
            DropIndex("dbo.ConsumptionItems", new[] { "ProsumerId" });
            DropIndex("dbo.Prosumers", new[] { "SmartMeterId" });
            //DropIndex("dbo.Affiliations", new[] { "ProsumerId" });
            //DropIndex("dbo.Affiliations", new[] { "MemberId" });
            DropTable("dbo.ProductionItems");
            DropTable("dbo.ConsumptionItems");
            DropTable("dbo.SmartMeters");
            DropTable("dbo.Prosumers");
            DropTable("dbo.Members");
            //DropTable("dbo.Affiliations");
        }
    }
}
