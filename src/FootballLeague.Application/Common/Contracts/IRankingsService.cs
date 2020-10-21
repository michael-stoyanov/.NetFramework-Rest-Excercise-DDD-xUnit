namespace FootballLeague.Application.Common.Contracts
{
    using FootballLeague.Application.Common.Models.DTOs;
    using FootballLeague.Application.Common.Models.InputModels.TeamModels;
    using System.Collections.Generic;

    public interface IRankingsService
    {
        void AddTeamScoreById(int teamId, int score);
        TeamDto GetChampionshipWinner();
        int GetTeamTotalScore(int teamId);
        List<TeamDto> GetTopTenTeams();
    }
}
