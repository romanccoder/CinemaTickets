namespace CinemaTickets.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sessionfilmhallrequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sessions", "AssociatedFilm_FilmId", "dbo.Films");
            DropForeignKey("dbo.Sessions", "AssociatedHall_HallId", "dbo.Halls");
            DropIndex("dbo.Sessions", new[] { "AssociatedFilm_FilmId" });
            DropIndex("dbo.Sessions", new[] { "AssociatedHall_HallId" });
            AlterColumn("dbo.Sessions", "AssociatedFilm_FilmId", c => c.Int(nullable: false));
            AlterColumn("dbo.Sessions", "AssociatedHall_HallId", c => c.Int(nullable: false));
            CreateIndex("dbo.Sessions", "AssociatedFilm_FilmId");
            CreateIndex("dbo.Sessions", "AssociatedHall_HallId");
            AddForeignKey("dbo.Sessions", "AssociatedFilm_FilmId", "dbo.Films", "FilmId", cascadeDelete: true);
            AddForeignKey("dbo.Sessions", "AssociatedHall_HallId", "dbo.Halls", "HallId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sessions", "AssociatedHall_HallId", "dbo.Halls");
            DropForeignKey("dbo.Sessions", "AssociatedFilm_FilmId", "dbo.Films");
            DropIndex("dbo.Sessions", new[] { "AssociatedHall_HallId" });
            DropIndex("dbo.Sessions", new[] { "AssociatedFilm_FilmId" });
            AlterColumn("dbo.Sessions", "AssociatedHall_HallId", c => c.Int());
            AlterColumn("dbo.Sessions", "AssociatedFilm_FilmId", c => c.Int());
            CreateIndex("dbo.Sessions", "AssociatedHall_HallId");
            CreateIndex("dbo.Sessions", "AssociatedFilm_FilmId");
            AddForeignKey("dbo.Sessions", "AssociatedHall_HallId", "dbo.Halls", "HallId");
            AddForeignKey("dbo.Sessions", "AssociatedFilm_FilmId", "dbo.Films", "FilmId");
        }
    }
}
