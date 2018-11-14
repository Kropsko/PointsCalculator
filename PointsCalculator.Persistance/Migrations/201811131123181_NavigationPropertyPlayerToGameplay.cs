namespace PointsCalculator.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NavigationPropertyPlayerToGameplay : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlayerGameplays",
                c => new
                    {
                        Player_Id = c.Int(nullable: false),
                        Gameplay_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Player_Id, t.Gameplay_Id })
                .ForeignKey("dbo.Players", t => t.Player_Id, cascadeDelete: true)
                .ForeignKey("dbo.Gameplays", t => t.Gameplay_Id, cascadeDelete: true)
                .Index(t => t.Player_Id)
                .Index(t => t.Gameplay_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayerGameplays", "Gameplay_Id", "dbo.Gameplays");
            DropForeignKey("dbo.PlayerGameplays", "Player_Id", "dbo.Players");
            DropIndex("dbo.PlayerGameplays", new[] { "Gameplay_Id" });
            DropIndex("dbo.PlayerGameplays", new[] { "Player_Id" });
            DropTable("dbo.PlayerGameplays");
        }
    }
}
