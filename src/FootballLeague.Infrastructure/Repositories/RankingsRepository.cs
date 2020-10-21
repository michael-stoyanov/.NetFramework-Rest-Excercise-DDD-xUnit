namespace FootballLeague.Infrastructure.Repositories
{
    using FootballLeague.Domain.Contracts;
    using FootballLeague.Domain.Entities;
    using FootballLeague.Infrastructure.Persistence;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RankingsRepository : IRankingsRepository
    {
        private const int topTeamsCountToTake = 10;
        private readonly LeagueDbContext leagueDb;

        public RankingsRepository(LeagueDbContext leagueDb)
        {
            this.leagueDb = leagueDb;
        }

        public List<Team> GetTopTenTeams()
        {
            return this.leagueDb.TeamsScores
                                    .OrderByDescending(c => c.TotalScore)
                                    .Take(topTeamsCountToTake)
                                    .Select(t => t.Team)
                                    .ToList();
        }

        public TeamScore GetTeamTotalScore(int teamId)
        {
            var team = this.leagueDb.TeamsScores.SingleOrDefault(t => t.Team.Id.Equals(teamId));

            if (team is null)
                throw new ArgumentException("There is no team registered with the passed id.");

            return team;
        }

        public Team GetChampionshipWinner()
        {
            // This has to be thought out to compare for equal scores of 2 or more teams 
            // OR think of some other way of choosing the winner amongst them

            var winner = this.leagueDb.TeamsScores
                                    .OrderByDescending(c => c.TotalScore)
                                    .Take(1)
                                    .Select(t => t.Team)
                                    .Single();

            if (winner is null)
                throw new ArgumentException("There is no team registered with the passed id.");

            return winner;
        }

        public void AddTeamScore(int teamId, int score)
        {
            TeamScore teamScore = this.leagueDb.TeamsScores.SingleOrDefault(t => t.Team.Id.Equals(teamId));

            if (teamScore is null)
            {
                Team team = this.leagueDb.Teams.SingleOrDefault(t => t.Id.Equals(teamId));

                if (team is null)
                    throw new ArgumentException("There is no team registered with this id.");

                teamScore = new TeamScore() { Team = team, TotalScore = score };

                this.leagueDb.TeamsScores.Add(teamScore);
            }
            else
            {
                teamScore.TotalScore += score;
            }

            this.leagueDb.SaveChanges();
        }
    }
}
