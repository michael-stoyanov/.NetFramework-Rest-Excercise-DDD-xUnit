namespace FootballLeague.Domain.Contracts
{
    using FootballLeague.Domain.Entities;
    using System.Collections.Generic;

    public interface ITeamRepository
    {
        Team ChangeTeamName(int teamId, string newTeamName);

        Team CreateTeam(string teamName);

        List<Team> GetAllTeams();

        Team GetTeamById(int teamId);
        
        Team DeleteTeam(int teamId);
    }
}
