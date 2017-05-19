namespace CinemaTickets.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSessionDatedatetime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sessions", "Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sessions", "Date", c => c.DateTime(nullable: false));
        }
    }
}
