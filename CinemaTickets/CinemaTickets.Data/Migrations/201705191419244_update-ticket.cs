namespace CinemaTickets.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateticket : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "AssociatedSession_SessionId", "dbo.Sessions");
            DropIndex("dbo.Tickets", new[] { "AssociatedSession_SessionId" });
            AlterColumn("dbo.Tickets", "AssociatedSession_SessionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "AssociatedSession_SessionId");
            AddForeignKey("dbo.Tickets", "AssociatedSession_SessionId", "dbo.Sessions", "SessionId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "AssociatedSession_SessionId", "dbo.Sessions");
            DropIndex("dbo.Tickets", new[] { "AssociatedSession_SessionId" });
            AlterColumn("dbo.Tickets", "AssociatedSession_SessionId", c => c.Int());
            CreateIndex("dbo.Tickets", "AssociatedSession_SessionId");
            AddForeignKey("dbo.Tickets", "AssociatedSession_SessionId", "dbo.Sessions", "SessionId");
        }
    }
}
