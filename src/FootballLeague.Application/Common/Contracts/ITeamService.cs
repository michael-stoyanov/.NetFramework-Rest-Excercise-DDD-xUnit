namespace FootballLeague.Application.Common.Contracts
{
    using FootballLeague.Application.Common.Models.DTOs;
    using FootballLeague.Application.Common.Models.InputModels;
    using FootballLeague.Application.Common.Models.InputModels.TeamModels;
    using System.Collections.Generic;

    public interface ITeamService
    {
        List<TeamDto> GetAllRegisteredTeams();

        TeamDto GetTeamById(int teamId);

        TeamDto CreateTeam(CreateTeamInputModel teamInfo);

        TeamDto ChangeTeamName(ChangeTeamNameInputModel teamNames);

        TeamDto DeleteTeam(DeleteTeamInputModel teamToDelete);
    }
}
