namespace ProsumerInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Infoes",
                c => new
                    {
                        ProsumerId = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProsumerId);
            
            CreateTable(
                "dbo.Prosumptions",
                c => new
                    {
                        ProsumptionId = c.Int(nullable: false, identity: true),
                        Production = c.Double(nullable: false),
                        Consumption = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                        SmartMeter = c.String(nullable: false),
                        ProsumerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProsumptionId)
                .ForeignKey("dbo.Infoes", t => t.ProsumerId, cascadeDelete: true)
                .Index(t => t.ProsumerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prosumptions", "ProsumerId", "dbo.Infoes");
            DropIndex("dbo.Prosumptions", new[] { "ProsumerId" });
            DropTable("dbo.Prosumptions");
            DropTable("dbo.Infoes");
        }
    }
}
