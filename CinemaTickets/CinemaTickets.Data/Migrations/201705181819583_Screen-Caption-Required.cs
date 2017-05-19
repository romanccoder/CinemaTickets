namespace CinemaTickets.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScreenCaptionRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Screens", "Caption", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Screens", "Caption", c => c.String());
        }
    }
}
