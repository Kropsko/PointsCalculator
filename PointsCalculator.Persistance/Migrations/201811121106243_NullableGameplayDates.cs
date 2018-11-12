namespace PointsCalculator.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableGameplayDates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Gameplays", "Start", c => c.DateTime());
            AlterColumn("dbo.Gameplays", "End", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Gameplays", "End", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Gameplays", "Start", c => c.DateTime(nullable: false));
        }
    }
}
