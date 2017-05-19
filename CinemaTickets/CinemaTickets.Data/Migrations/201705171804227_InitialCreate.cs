namespace CinemaTickets.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        FilmId = c.Int(nullable: false, identity: true),
                        Caption = c.String(),
                        Description = c.String(unicode: false, storeType: "text"),
                        ReleaseDate = c.DateTime(nullable: false, storeType: "date"),
                        ImageName = c.String(),
                    })
                .PrimaryKey(t => t.FilmId);
            
            CreateTable(
                "dbo.Halls",
                c => new
                    {
                        HallId = c.Int(nullable: false, identity: true),
                        Caption = c.String(),
                        Rows = c.Int(nullable: false),
                        PlacesPerRow = c.Int(nullable: false),
                        AssociatedScreen_ScreenId = c.Int(),
                    })
                .PrimaryKey(t => t.HallId)
                .ForeignKey("dbo.Screens", t => t.AssociatedScreen_ScreenId)
                .Index(t => t.AssociatedScreen_ScreenId);
            
            CreateTable(
                "dbo.Screens",
                c => new
                    {
                        ScreenId = c.Int(nullable: false, identity: true),
                        Caption = c.String(),
                    })
                .PrimaryKey(t => t.ScreenId);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        SessionId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        AssociatedFilm_FilmId = c.Int(),
                        AssociatedHall_HallId = c.Int(),
                    })
                .PrimaryKey(t => t.SessionId)
                .ForeignKey("dbo.Films", t => t.AssociatedFilm_FilmId)
                .ForeignKey("dbo.Halls", t => t.AssociatedHall_HallId)
                .Index(t => t.AssociatedFilm_FilmId)
                .Index(t => t.AssociatedHall_HallId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        Row = c.Int(nullable: false),
                        Place = c.Int(nullable: false),
                        LastStatus = c.Int(nullable: false),
                        AssociatedSession_SessionId = c.Int(),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.Sessions", t => t.AssociatedSession_SessionId)
                .Index(t => t.AssociatedSession_SessionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "AssociatedSession_SessionId", "dbo.Sessions");
            DropForeignKey("dbo.Sessions", "AssociatedHall_HallId", "dbo.Halls");
            DropForeignKey("dbo.Sessions", "AssociatedFilm_FilmId", "dbo.Films");
            DropForeignKey("dbo.Halls", "AssociatedScreen_ScreenId", "dbo.Screens");
            DropIndex("dbo.Tickets", new[] { "AssociatedSession_SessionId" });
            DropIndex("dbo.Sessions", new[] { "AssociatedHall_HallId" });
            DropIndex("dbo.Sessions", new[] { "AssociatedFilm_FilmId" });
            DropIndex("dbo.Halls", new[] { "AssociatedScreen_ScreenId" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Sessions");
            DropTable("dbo.Screens");
            DropTable("dbo.Halls");
            DropTable("dbo.Films");
        }
    }
}
