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
                "dbo.Plays",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTimeOffset(nullable: false, precision: 7),
                        Winner = c.String(nullable: false),
                        BoardGameID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BoardGames", t => t.BoardGameID)
                .Index(t => t.BoardGameID);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        ID = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                        Ranking = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Statistics",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
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
                "dbo.Play_Player",
                c => new
                    {
                        PlayID = c.Int(nullable: false),
                        PlayerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PlayID, t.PlayerID })
                .ForeignKey("dbo.Plays", t => t.PlayID, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.PlayerID, cascadeDelete: true)
                .Index(t => t.PlayID)
                .Index(t => t.PlayerID);
            
            CreateTable(
                "dbo.Statistic_Play",
                c => new
                    {
                        StatisticID = c.Int(nullable: false),
                        PlayID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StatisticID, t.PlayID })
                .ForeignKey("dbo.Statistics", t => t.StatisticID, cascadeDelete: true)
                .ForeignKey("dbo.Plays", t => t.PlayID, cascadeDelete: true)
                .Index(t => t.StatisticID)
                .Index(t => t.PlayID);
            
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
            DropForeignKey("dbo.Statistic_Play", "PlayID", "dbo.Plays");
            DropForeignKey("dbo.Statistic_Play", "StatisticID", "dbo.Statistics");
            DropForeignKey("dbo.Play_Player", "PlayerID", "dbo.Players");
            DropForeignKey("dbo.Play_Player", "PlayID", "dbo.Plays");
            DropForeignKey("dbo.Plays", "BoardGameID", "dbo.BoardGames");
            DropForeignKey("dbo.BoardGame_BoardGameCategory", "BoardGameCategoryID", "dbo.BoardGameCategories");
            DropForeignKey("dbo.BoardGame_BoardGameCategory", "BoardGameID", "dbo.BoardGames");
            DropIndex("dbo.User_BoardGame", new[] { "BoardGameID" });
            DropIndex("dbo.User_BoardGame", new[] { "UserID" });
            DropIndex("dbo.Statistic_Play", new[] { "PlayID" });
            DropIndex("dbo.Statistic_Play", new[] { "StatisticID" });
            DropIndex("dbo.Play_Player", new[] { "PlayerID" });
            DropIndex("dbo.Play_Player", new[] { "PlayID" });
            DropIndex("dbo.BoardGame_BoardGameCategory", new[] { "BoardGameCategoryID" });
            DropIndex("dbo.BoardGame_BoardGameCategory", new[] { "BoardGameID" });
            DropIndex("dbo.Plays", new[] { "BoardGameID" });
            DropTable("dbo.User_BoardGame");
            DropTable("dbo.Statistic_Play");
            DropTable("dbo.Play_Player");
            DropTable("dbo.BoardGame_BoardGameCategory");
            DropTable("dbo.Users");
            DropTable("dbo.Statistics");
            DropTable("dbo.Players");
            DropTable("dbo.Plays");
            DropTable("dbo.BoardGames");
            DropTable("dbo.BoardGameCategories");
        }
    }
}
