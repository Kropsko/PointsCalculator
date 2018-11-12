namespace PointsCalculator.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameplayId = c.Int(nullable: false),
                        PlayerId = c.Int(nullable: false),
                        ActionType = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gameplays", t => t.GameplayId, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.GameplayId)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.Gameplays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsEnded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        DeleteDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Configurations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameplayID = c.Int(nullable: false),
                        PlayerId = c.Int(nullable: false),
                        Color = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gameplays", t => t.GameplayID, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.GameplayID)
                .Index(t => t.PlayerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Configurations", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Configurations", "GameplayID", "dbo.Gameplays");
            DropForeignKey("dbo.Actions", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Actions", "GameplayId", "dbo.Gameplays");
            DropIndex("dbo.Configurations", new[] { "PlayerId" });
            DropIndex("dbo.Configurations", new[] { "GameplayID" });
            DropIndex("dbo.Actions", new[] { "PlayerId" });
            DropIndex("dbo.Actions", new[] { "GameplayId" });
            DropTable("dbo.Configurations");
            DropTable("dbo.Players");
            DropTable("dbo.Gameplays");
            DropTable("dbo.Actions");
        }
    }
}
