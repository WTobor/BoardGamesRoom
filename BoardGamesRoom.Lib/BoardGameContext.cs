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
            Database.SetInitializer<BoardGameContext>(null);
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

            //many-to-many 
            modelBuilder.Entity<User>()
                .HasMany<BoardGame>(b => b.Games)
                .WithMany(u => u.Users)
                .Map(bu =>
                {
                    bu.MapLeftKey("UserID");
                    bu.MapRightKey("BoardGameID");
                    bu.ToTable("User_BoardGame");
                });

            modelBuilder.Entity<Play>()
                    .HasRequired(p => p.BoardGame)
                    .WithMany(b => b.Plays)
                    .HasForeignKey(p => p.BoardGameID)
                    .WillCascadeOnDelete(false);

            //many-to-many 
            modelBuilder.Entity<Play>()
                .HasMany<Player>(p => p.Players)
                .WithMany(x => x.Plays)
                .Map(px =>
                {
                    px.MapLeftKey("PlayID");
                    px.MapRightKey("PlayerID");
                    px.ToTable("Play_Player");
                });

            modelBuilder.Entity<Player>()
                .HasKey(x => x.UserID);

            //many-to-many 
            modelBuilder.Entity<Statistic>()
                .HasMany<Play>(p => p.Plays)
                .WithMany(x => x.Statistics)
                .Map(px =>
                {
                    px.MapLeftKey("StatisticID");
                    px.MapRightKey("PlayID");
                    px.ToTable("Statistic_Play");
                });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<BoardGameCategory> BoardGameCategories { get; set; }

        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Play> Play { get; set; }
    }
}
