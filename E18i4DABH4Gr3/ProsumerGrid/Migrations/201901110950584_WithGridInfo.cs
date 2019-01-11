namespace ProsumerGrid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WithGridInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grids",
                c => new
                    {
                        GridId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Balance = c.Double(nullable: false),
                        BlockExchangeValue = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.GridId);
            
            CreateTable(
                "dbo.Nodes",
                c => new
                    {
                        NodeId = c.Int(nullable: false, identity: true),
                        Balance = c.Double(nullable: false),
                        ProsumerId = c.Int(nullable: false),
                        GridId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NodeId)
                .ForeignKey("dbo.Grids", t => t.GridId, cascadeDelete: true)
                .ForeignKey("dbo.Prosumers", t => t.ProsumerId, cascadeDelete: true)
                .Index(t => t.ProsumerId)
                .Index(t => t.GridId);
            
            AddColumn("dbo.SmartMeters", "Balance", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Nodes", "ProsumerId", "dbo.Prosumers");
            DropForeignKey("dbo.Nodes", "GridId", "dbo.Grids");
            DropIndex("dbo.Nodes", new[] { "GridId" });
            DropIndex("dbo.Nodes", new[] { "ProsumerId" });
            DropColumn("dbo.SmartMeters", "Balance");
            DropTable("dbo.Nodes");
            DropTable("dbo.Grids");
        }
    }
}
