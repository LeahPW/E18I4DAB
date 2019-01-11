namespace ProsumerGrid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WithGridInfo1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ConsumptionItems", "ProsumerId", "dbo.Prosumers");
            DropForeignKey("dbo.ProductionItems", "ProsumerId", "dbo.Prosumers");
            DropIndex("dbo.ConsumptionItems", new[] { "ProsumerId" });
            DropIndex("dbo.ProductionItems", new[] { "ProsumerId" });
            CreateTable(
                "dbo.ConsumptionDevices",
                c => new
                    {
                        ConDeviceId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Consumption = c.Double(nullable: false),
                        ProsumerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConDeviceId)
                .ForeignKey("dbo.Prosumers", t => t.ProsumerId, cascadeDelete: true)
                .Index(t => t.ProsumerId);
            
            CreateTable(
                "dbo.ProductionDevices",
                c => new
                    {
                        ProDeviceId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Production = c.Double(nullable: false),
                        ProsumerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProDeviceId)
                .ForeignKey("dbo.Prosumers", t => t.ProsumerId, cascadeDelete: true)
                .Index(t => t.ProsumerId);
            
            DropTable("dbo.ConsumptionItems");
            DropTable("dbo.ProductionItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductionItems",
                c => new
                    {
                        ProItemId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Production = c.Double(nullable: false),
                        ProsumerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProItemId);
            
            CreateTable(
                "dbo.ConsumptionItems",
                c => new
                    {
                        ConItemId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Consumption = c.Double(nullable: false),
                        ProsumerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConItemId);
            
            DropForeignKey("dbo.ProductionDevices", "ProsumerId", "dbo.Prosumers");
            DropForeignKey("dbo.ConsumptionDevices", "ProsumerId", "dbo.Prosumers");
            DropIndex("dbo.ProductionDevices", new[] { "ProsumerId" });
            DropIndex("dbo.ConsumptionDevices", new[] { "ProsumerId" });
            DropTable("dbo.ProductionDevices");
            DropTable("dbo.ConsumptionDevices");
            CreateIndex("dbo.ProductionItems", "ProsumerId");
            CreateIndex("dbo.ConsumptionItems", "ProsumerId");
            AddForeignKey("dbo.ProductionItems", "ProsumerId", "dbo.Prosumers", "ProsumerId", cascadeDelete: true);
            AddForeignKey("dbo.ConsumptionItems", "ProsumerId", "dbo.Prosumers", "ProsumerId", cascadeDelete: true);
        }
    }
}
