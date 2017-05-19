namespace CinemaTickets.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveFilmImageName : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Films", "ImageName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Films", "ImageName", c => c.String());
        }
    }
}
