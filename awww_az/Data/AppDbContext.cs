using Microsoft.EntityFrameworkCore;
using awww_az.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace awww_az.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchEvent> MatchEvents { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<MatchPlayer> MatchPlayers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Tu możesz dodać dodatkową konfigurację Fluent API, np. relacje wiele-do-wielu.
        }
    }
}

// dotnet add package Microsoft.EntityFrameworkCore.SqlServer
// dotnet add package Microsoft.EntityFrameworkCore
// dotnet add package Microsoft.EntityFrameworkCore.Design
// dotnet add package Microsoft.EntityFrameworkCore.Tools
// dotnet tool install --global dotnet-ef
