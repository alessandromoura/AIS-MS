using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketsCorinthiansCore.Entities
{
    public class DbInitializer
    {
        public static void Initialize(TicketsDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Championships.Any())
            {
                var championships = new ChampionshipEntity[]
                {
                    new ChampionshipEntity { Id = Guid.Parse("CAE62105-0F21-4BFF-8C3B-A6FAB99F6E67"), Name = "Brasileirao", Trophy = null, Year = 1976 },
                    new ChampionshipEntity { Id = Guid.Parse("EA0082B2-EEB7-458E-9C90-1E7A865FCD3E"), Name = "Paulista", Trophy = null, Year = 1977 },
                    new ChampionshipEntity { Id = Guid.Parse("6362570D-24E9-4FBD-827C-A96E5A4CAFFD"), Name = "Brasileirao", Trophy = null, Year = 1990 },
                    new ChampionshipEntity { Id = Guid.Parse("59C6FE8C-6208-4462-B1B3-FB56864C7045"), Name = "Club World Cup", Trophy = null, Year = 2000 },
                    new ChampionshipEntity { Id = Guid.Parse("631D5AA7-2FAF-4ABF-B312-926D1B2A75B3"), Name = "Paulista", Trophy = null, Year = 2009 },
                    new ChampionshipEntity { Id = Guid.Parse("7ECA68B0-02D5-4536-A2AF-9756B4628FC1"), Name = "Libertadores", Trophy = null, Year = 2012 },
                    new ChampionshipEntity { Id = Guid.Parse("0C5B25CB-FE35-4B59-ADE1-0E99441D52C4"), Name = "Club World Cup", Trophy = null, Year = 2012 }
                };
                foreach (var item in championships)
                {
                    context.Championships.Add(item);
                }
                context.SaveChanges();
            }

            if (!context.Teams.Any())
            {
                var teams = new TeamEntity[]
                {
                    new TeamEntity { Id = Guid.Parse("946909A7-4A30-4470-9CBB-69710A4F8A4F"), Name = "Corinthians", Logo = null },
                    new TeamEntity { Id = Guid.Parse("706DEC11-300D-4036-8277-DDC89D4DDD28"), Name = "Fluminense", Logo = null },
                    new TeamEntity { Id = Guid.Parse("6F77840A-0F49-4B72-B92B-8BFFCFC71F3C"), Name = "Ponte Preta", Logo = null },
                    new TeamEntity { Id = Guid.Parse("755AE6B2-71F6-4CCC-9F06-779A87168DFD"), Name = "Sao Paulo", Logo = null },
                    new TeamEntity { Id = Guid.Parse("D0EDADE1-5382-4B93-A98A-7391A9B59BAD"), Name = "Vasco", Logo = null },
                    new TeamEntity { Id = Guid.Parse("0F0351D9-9DE6-4A9C-B195-254FC6834E3C"), Name = "Santos", Logo = null },
                    new TeamEntity { Id = Guid.Parse("1815A9F3-27A5-49B8-9225-5F1FC55FAF0E"), Name = "Boca Juniors", Logo = null },
                    new TeamEntity { Id = Guid.Parse("4E66B19E-B0F6-4A32-9C77-0A4917CFE576"), Name = "Chelsea", Logo = null }
                };
                foreach (var item in teams)
                {
                    context.Teams.Add(item);
                }
                context.SaveChanges();
            }

            if (!context.Stadiums.Any())
            {
                var stadiums = new StadiumEntity[]
                {
                    new StadiumEntity { Id = Guid.Parse("98D4D5C4-B7C8-4C42-B075-995F76DE01FF"), Name = "Morumbi", City = "Sao Paulo", Country = "Brazil" },
                    new StadiumEntity { Id = Guid.Parse("D5F757D6-8B05-4F30-AD03-4FFD986C2C5F"), Name = "Pacaembu", City = "Sao Paulo", Country = "Brazil" },
                    new StadiumEntity { Id = Guid.Parse("588D9129-CBB5-49A6-99A1-C98771935500"), Name = "Maracana", City = "Rio de Janeiro", Country = "Brazil" },
                    new StadiumEntity { Id = Guid.Parse("2FA3FB7D-73CA-404A-B24C-87FC77B5523D"), Name = "Vila Belmiro", City = "Santos", Country = "Brazil" },
                    new StadiumEntity { Id = Guid.Parse("88F54F84-6FDA-4E0A-A627-F3B3D6D5EC61"), Name = "Nissan Staidum", City = "Yokohama", Country = "Japan" }
                };
                foreach (var item in stadiums)
                {
                    context.Stadiums.Add(item);
                }
                context.SaveChanges();
            }

            if (!context.Games.Any())
            {
                var games = new GameEntity[]
                {
                    // 1976
                    new GameEntity { Id = new Guid(), ChampionshipId = Guid.Parse("CAE62105-0F21-4BFF-8C3B-A6FAB99F6E67"), StadiumId = Guid.Parse("588D9129-CBB5-49A6-99A1-C98771935500"), TeamHomeId = Guid.Parse("706DEC11-300D-4036-8277-DDC89D4DDD28"), TeamAwayId = Guid.Parse("946909A7-4A30-4470-9CBB-69710A4F8A4F") },
                    // 1977
                    new GameEntity { Id = new Guid(), ChampionshipId = Guid.Parse("EA0082B2-EEB7-458E-9C90-1E7A865FCD3E"), StadiumId = Guid.Parse("98D4D5C4-B7C8-4C42-B075-995F76DE01FF"), TeamHomeId = Guid.Parse("946909A7-4A30-4470-9CBB-69710A4F8A4F"), TeamAwayId = Guid.Parse("6F77840A-0F49-4B72-B92B-8BFFCFC71F3C") },
                    // 2000
                    new GameEntity { Id = new Guid(), ChampionshipId = Guid.Parse("59C6FE8C-6208-4462-B1B3-FB56864C7045"), StadiumId = Guid.Parse("588D9129-CBB5-49A6-99A1-C98771935500"), TeamHomeId = Guid.Parse("946909A7-4A30-4470-9CBB-69710A4F8A4F"), TeamAwayId = Guid.Parse("D0EDADE1-5382-4B93-A98A-7391A9B59BAD") },
                    // 2009
                    new GameEntity { Id = new Guid(), ChampionshipId = Guid.Parse("631D5AA7-2FAF-4ABF-B312-926D1B2A75B3"), StadiumId = Guid.Parse("2FA3FB7D-73CA-404A-B24C-87FC77B5523D"), TeamHomeId = Guid.Parse("0F0351D9-9DE6-4A9C-B195-254FC6834E3C"), TeamAwayId = Guid.Parse("946909A7-4A30-4470-9CBB-69710A4F8A4F") },
                    // 2012 Libertadores
                    new GameEntity { Id = new Guid(), ChampionshipId = Guid.Parse("7ECA68B0-02D5-4536-A2AF-9756B4628FC1"), StadiumId = Guid.Parse("D5F757D6-8B05-4F30-AD03-4FFD986C2C5F"), TeamHomeId = Guid.Parse("946909A7-4A30-4470-9CBB-69710A4F8A4F"), TeamAwayId = Guid.Parse("1815A9F3-27A5-49B8-9225-5F1FC55FAF0E") },
                    // 2012 Club World Cup
                    new GameEntity { Id = new Guid(), ChampionshipId = Guid.Parse("0C5B25CB-FE35-4B59-ADE1-0E99441D52C4"), StadiumId = Guid.Parse("88F54F84-6FDA-4E0A-A627-F3B3D6D5EC61"), TeamHomeId = Guid.Parse("946909A7-4A30-4470-9CBB-69710A4F8A4F"), TeamAwayId = Guid.Parse("4E66B19E-B0F6-4A32-9C77-0A4917CFE576") }
                };
                foreach (var item in games)
                {
                    context.Games.Add(item);
                }
                context.SaveChanges();
            }
        }
    }
}
