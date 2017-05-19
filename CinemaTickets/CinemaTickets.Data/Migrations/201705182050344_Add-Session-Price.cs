namespace CinemaTickets.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSessionPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sessions", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sessions", "Price");
        }
    }
}
