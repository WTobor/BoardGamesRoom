namespace BoardGamesRoom.Lib.Migrations
{
    using Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BoardGamesRoom.Lib.BoardGameContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BoardGameContext context)
        {
            context.BoardGameCategories.AddOrUpdate(x => x.ID,
                new BoardGameCategory() { ID = 1, Name = "Familijne" },
                new BoardGameCategory() { ID = 2, Name = "Imprezowe" },
                new BoardGameCategory() { ID = 3, Name = "Ekonomiczne" },
                new BoardGameCategory() { ID = 4, Name = "Strategiczne" },
                new BoardGameCategory() { ID = 5, Name = "Wojenne" },
                new BoardGameCategory() { ID = 6, Name = "Przygodowe" },
                new BoardGameCategory() { ID = 7, Name = "Kooperacyjne" },
                new BoardGameCategory() { ID = 8, Name = "Gry karciane" },
                new BoardGameCategory() { ID = 9, Name = "Gry koœciane" },
                new BoardGameCategory() { ID = 10, Name = "Logiczne" },
                new BoardGameCategory() { ID = 11, Name = "Wyœcigowe i sportowe" },
                new BoardGameCategory() { ID = 12, Name = "Gry dla 1 osoby" },
                new BoardGameCategory() { ID = 13, Name = "Gry dla 2 osób" },
                new BoardGameCategory() { ID = 14, Name = "Gry podró¿ne" },
                new BoardGameCategory() { ID = 15, Name = "Gry plenerowe" },
                new BoardGameCategory() { ID = 16, Name = "S³owne i liczbowe" },
                new BoardGameCategory() { ID = 17, Name = "Ró¿ne" },
                new BoardGameCategory() { ID = 18, Name = "Ze zwierzêtami" },
                new BoardGameCategory() { ID = 19, Name = "Gry japoñskie" },
                new BoardGameCategory() { ID = 20, Name = "Gry dla doros³ych" },
                new BoardGameCategory() { ID = 21, Name = "Edukacyjne" },
                new BoardGameCategory() { ID = 22, Name = "Dodatki do gier" }
                );
            context.SaveChanges();

            var osadnicyCat = context.BoardGameCategories.Where(x => x.ID == 3 || x.ID == 4).ToList();
            var splendorCat = context.BoardGameCategories.Where(x => x.ID == 10 || x.ID == 4).ToList();
            var sabotazCat = context.BoardGameCategories.Where(x => x.ID == 8).ToList();

            context.BoardGames.AddOrUpdate(x => x.ID,
                new BoardGame() { ID = 1, Name = "Osadnicy z Catanu", Categories = osadnicyCat, MinNumberOfPlayers = 2, MaxNumberOfPlayers = 4 },
                new BoardGame() { ID = 2, Name = "Splendor", Categories = splendorCat, MinNumberOfPlayers = 2, MaxNumberOfPlayers = 4 },
                new BoardGame() { ID = 3, Name = "Sabota¿ysta", Categories = sabotazCat, MinNumberOfPlayers = 2, MaxNumberOfPlayers = 6 }
                );
            context.SaveChanges();

            var werciaGames = context.BoardGames.Where(x => x.ID == 1 || x.ID == 2).ToList();
            var lukaszGames = context.BoardGames.Where(x => x.ID == 3).ToList();

            context.Users.AddOrUpdate(x => x.ID,
                new User() { ID = 1, Login = "wercia", Password = "wercia", Games = werciaGames }, 
                new User() { ID = 2, Login = "lukasz", Password = "lukasz", Games = lukaszGames }
                );
            context.SaveChanges();

            context.Player.AddOrUpdate(x => x.ID,
                new Player() { ID = 1, UserID=1, Points=90, Ranking=1 },
                new Player() { ID = 2, UserID = 2, Points = 70, Ranking = 2 }
                );
            context.SaveChanges();

            var players = context.Player.Where(x => x.ID == 1 || x.ID == 2).ToList();
            var boardGame = context.BoardGames.Where(x => x.ID == 1 ).FirstOrDefault();

            context.Play.AddOrUpdate(x => x.ID,
                new Play() { ID = 1, Date = DateTimeOffset.Now, Players = players, BoardGameID = 1, BoardGame = boardGame, Winner="werka zwycięzca" }
                );
            context.SaveChanges();

            var plays = context.Play.ToList();

            context.Statistics.AddOrUpdate(x => x.ID,
                new Statistic() { ID = 1, Plays = plays }
                );
            context.SaveChanges();
        }
    }
}
