namespace PointsCalculator.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullablePlayerDates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Players", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.Players", "DeleteDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Players", "DeleteDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Players", "CreateDate", c => c.DateTime(nullable: false));
        }
    }
}
