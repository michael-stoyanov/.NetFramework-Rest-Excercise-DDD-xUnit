namespace FootballLeague.Infrastructure.Repositories
{
    using FootballLeague.Domain.Contracts;
    using FootballLeague.Infrastructure.Persistence;

    public class MatchRepository : IMatchRepository
    {
        private readonly LeagueDbContext leagueDb;

        public MatchRepository(LeagueDbContext leagueDb)
        {
            this.leagueDb = leagueDb;
        }
    }
}
