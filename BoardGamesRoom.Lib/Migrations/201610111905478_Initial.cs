namespace BoardGamesRoom.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BoardGameCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BoardGames",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        MinNumberOfPlayers = c.Int(nullable: false),
                        MaxNumberOfPlayers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BoardGame_BoardGameCategory",
                c => new
                    {
                        BoardGameID = c.Int(nullable: false),
                        BoardGameCategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BoardGameID, t.BoardGameCategoryID })
                .ForeignKey("dbo.BoardGames", t => t.BoardGameID, cascadeDelete: true)
                .ForeignKey("dbo.BoardGameCategories", t => t.BoardGameCategoryID, cascadeDelete: true)
                .Index(t => t.BoardGameID)
                .Index(t => t.BoardGameCategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BoardGame_BoardGameCategory", "BoardGameCategoryID", "dbo.BoardGameCategories");
            DropForeignKey("dbo.BoardGame_BoardGameCategory", "BoardGameID", "dbo.BoardGames");
            DropIndex("dbo.BoardGame_BoardGameCategory", new[] { "BoardGameCategoryID" });
            DropIndex("dbo.BoardGame_BoardGameCategory", new[] { "BoardGameID" });
            DropTable("dbo.BoardGame_BoardGameCategory");
            DropTable("dbo.BoardGames");
            DropTable("dbo.BoardGameCategories");
        }
    }
}
