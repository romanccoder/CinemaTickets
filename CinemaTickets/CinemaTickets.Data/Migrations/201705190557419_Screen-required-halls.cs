namespace CinemaTickets.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Screenrequiredhalls : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Halls", "AssociatedScreen_ScreenId", "dbo.Screens");
            DropIndex("dbo.Halls", new[] { "AssociatedScreen_ScreenId" });
            AlterColumn("dbo.Halls", "AssociatedScreen_ScreenId", c => c.Int(nullable: false));
            CreateIndex("dbo.Halls", "AssociatedScreen_ScreenId");
            AddForeignKey("dbo.Halls", "AssociatedScreen_ScreenId", "dbo.Screens", "ScreenId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Halls", "AssociatedScreen_ScreenId", "dbo.Screens");
            DropIndex("dbo.Halls", new[] { "AssociatedScreen_ScreenId" });
            AlterColumn("dbo.Halls", "AssociatedScreen_ScreenId", c => c.Int());
            CreateIndex("dbo.Halls", "AssociatedScreen_ScreenId");
            AddForeignKey("dbo.Halls", "AssociatedScreen_ScreenId", "dbo.Screens", "ScreenId");
        }
    }
}
