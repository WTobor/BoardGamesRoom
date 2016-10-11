namespace BoardGamesRoom.Lib.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BoardGamesRoom.Model;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<BoardGameContext>
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
        }
    }
}
