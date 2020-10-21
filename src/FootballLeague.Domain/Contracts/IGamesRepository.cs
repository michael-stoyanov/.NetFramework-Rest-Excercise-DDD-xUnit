namespace FootballLeague.Domain.Contracts
{
    using FootballLeague.Domain.Entities;
    using System.Collections.Generic;

    public interface IGamesRepository
    {
        TeamsGames GetGameInfoById(int gameId);

        List<TeamsGames> GetAllPlayedGames();

        List<FootballGame> GetTeamGuestMatchesById(int teamId);

        List<FootballGame> GetTeamHomeMatchesById(int teamId);

        FootballGame RegisterGame(int homeTeamId, int guestTeamId, int homeTeamScore, int guestTeamScore);

        FootballGame UpdateGameScores(int gameId, int homeTeamScore, int guestTeamScore);

        FootballGame DeleteGame(int gameId);
    }
}
