namespace FootballLeague.Infrastructure.Repositories
{
    using FootballLeague.Domain.Contracts;
    using FootballLeague.Domain.Entities;
    using FootballLeague.Infrastructure.Persistence;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class TeamRepository : ITeamRepository
    {
        private readonly LeagueDbContext leagueDb;

        public TeamRepository(LeagueDbContext leagueDb)
        {
            this.leagueDb = leagueDb;
        }

        public List<Team> GetAllTeams()
        {
            List<Team> registeredTeams = this.leagueDb.Teams.ToList();

            if (registeredTeams.Count().Equals(0))
                throw new InvalidOperationException("There are no teams registered in the championship");

            return registeredTeams;
        }

        public Team GetTeamById(int teamId)
        {
            Team team = this.leagueDb.Teams.Where(t => t.Id.Equals(teamId))
                                           .Include(t => t.GuestGames)
                                           .Include(t => t.HomeGames)
                                           .SingleOrDefault();

            if (team is null)
                throw new InvalidOperationException("Team with this name is not registered in the championship");

            return team;
        }

        public Team CreateTeam(string teamName)
        {
            if (this.leagueDb.Teams.Any(t => t.Name.Equals(teamName, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException("Team with this name already exists.");

            var newTeam = new Team() { Name = teamName };

            this.leagueDb.Teams.Add(newTeam);

            this.leagueDb.SaveChanges();

            return newTeam;
        }

        public Team ChangeTeamName(int teamId, string newTeamName)
        {
            Team team = this.leagueDb.Teams.SingleOrDefault(t => t.Id.Equals(teamId));

            if (team is null)
                throw new InvalidOperationException("Team with this name is not registered in the championship.");

            if (this.leagueDb.Teams.Any(t => t.Name.Equals(newTeamName)))
                throw new InvalidOperationException("Team with this name is already registered in the championship.");

            team.Name = newTeamName;

            this.leagueDb.SaveChanges();

            return team;
        }

        public Team DeleteTeam(int teamId)
        {
            Team teamToDelete = this.leagueDb.Teams.SingleOrDefault(t => t.Id.Equals(teamId));

            if (teamToDelete is null)
                throw new InvalidOperationException("There is no team registered in the championship with this name.");

            this.leagueDb.Teams.Remove(teamToDelete);

            this.leagueDb.SaveChanges();

            return teamToDelete;
        }
    }
}
