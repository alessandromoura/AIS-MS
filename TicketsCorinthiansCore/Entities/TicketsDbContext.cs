using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketsCorinthiansCore.Entities
{
    public class TicketsDbContext: DbContext
    {
        public DbSet<StadiumEntity> Stadiums { get; set; }
        public DbSet<ChampionshipEntity> Championships { get; set; }
        public DbSet<TeamEntity> Teams { get; set; }
        public DbSet<GameEntity> Games { get; set; }

        public TicketsDbContext(DbContextOptions<TicketsDbContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<ChampionshipEntity>().HasData(
                new ChampionshipEntity()
                {
                    Id = Guid.Parse("CAE62105-0F21-4BFF-8C3B-A6FAB99F6E67"),
                    Name = "Brasileirao",
                    Trophy = null,
                    Year = 1976
                });*/

            modelBuilder.Entity<GameEntity>()
                .HasOne(t1 => t1.TeamAway)
                .WithMany(g => g.Games)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
