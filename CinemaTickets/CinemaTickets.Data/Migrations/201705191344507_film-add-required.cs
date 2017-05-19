namespace CinemaTickets.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class filmaddrequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Films", "Caption", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Films", "Caption", c => c.String());
        }
    }
}
