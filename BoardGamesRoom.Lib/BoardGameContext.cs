using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BoardGamesRoom.Model;

namespace BoardGamesRoom.Lib
{
    public class BoardGameContext : DbContext
    {    
        public BoardGameContext() : base("name=BoardGameContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //many-to-many 
            modelBuilder.Entity<BoardGame>()
                .HasMany<BoardGameCategory>(c => c.Categories)
                .WithMany(b => b.BoardGames)
                .Map(cb =>
                {
                    cb.MapLeftKey("BoardGameID");
                    cb.MapRightKey("BoardGameCategoryID");
                    cb.ToTable("BoardGame_BoardGameCategory");
                });
        }

        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<BoardGameCategory> BoardGameCategories { get; set; }
    }
}
