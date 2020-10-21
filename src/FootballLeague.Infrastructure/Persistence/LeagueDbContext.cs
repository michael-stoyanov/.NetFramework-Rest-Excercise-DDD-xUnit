namespace FootballLeague.Infrastructure.Persistence
{
    using FootballLeague.Domain.Entities;
    using System.Data.Entity;

    public class LeagueDbContext : DbContext
    {
        public virtual DbSet<Team> Teams { get; set; }
               
        public virtual DbSet<FootballGame> Games { get; set; }
               
        public virtual DbSet<TeamsGames> TeamsGames { get; set; }
               
        public virtual DbSet<TeamScore> TeamsScores { get; set; }

        public LeagueDbContext()
            : base("name=LeagueDbContext")
        {
        }
    }
}
