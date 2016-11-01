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
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
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
            
            CreateTable(
                "dbo.User_BoardGame",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        BoardGameID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.BoardGameID })
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.BoardGames", t => t.BoardGameID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.BoardGameID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User_BoardGame", "BoardGameID", "dbo.BoardGames");
            DropForeignKey("dbo.User_BoardGame", "UserID", "dbo.Users");
            DropForeignKey("dbo.BoardGame_BoardGameCategory", "BoardGameCategoryID", "dbo.BoardGameCategories");
            DropForeignKey("dbo.BoardGame_BoardGameCategory", "BoardGameID", "dbo.BoardGames");
            DropIndex("dbo.User_BoardGame", new[] { "BoardGameID" });
            DropIndex("dbo.User_BoardGame", new[] { "UserID" });
            DropIndex("dbo.BoardGame_BoardGameCategory", new[] { "BoardGameCategoryID" });
            DropIndex("dbo.BoardGame_BoardGameCategory", new[] { "BoardGameID" });
            DropTable("dbo.User_BoardGame");
            DropTable("dbo.BoardGame_BoardGameCategory");
            DropTable("dbo.Users");
            DropTable("dbo.BoardGames");
            DropTable("dbo.BoardGameCategories");
        }
    }
}