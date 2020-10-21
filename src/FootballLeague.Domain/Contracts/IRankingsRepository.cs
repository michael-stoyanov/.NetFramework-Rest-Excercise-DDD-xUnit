namespace FootballLeague.Domain.Contracts
{
    using FootballLeague.Domain.Entities;
    using System.Collections.Generic;

    public interface IRankingsRepository
    {
        TeamScore GetTeamTotalScore(int teamId);

        Team GetChampionshipWinner();

        List<Team> GetTopTenTeams();

        void AddTeamScore(int teamId, int score);
    }
}
