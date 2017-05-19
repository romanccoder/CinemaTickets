namespace CinemaTickets.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hallcaptionrequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Halls", "Caption", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Halls", "Caption", c => c.String());
        }
    }
}
