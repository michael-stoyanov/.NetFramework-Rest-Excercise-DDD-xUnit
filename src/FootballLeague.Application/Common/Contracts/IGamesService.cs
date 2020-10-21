namespace FootballLeague.Application.Common.Contracts
{
    using FootballLeague.Application.Common.Models.DTOs;
    using FootballLeague.Application.Common.Models.InputModels;
    using FootballLeague.Application.Common.Models.InputModels.GameModels;
    using System.Collections.Generic;

    public interface IGamesService
    {
        List<PlayedGameInfoDto> GetAllPlayedGamesInfo();

        PlayedGameInfoDto GetGameById(int gameId);

        GameDto RegisterGameInfo(CreateGameInputModel gameInfo);

        GameDto UpdateGameScores(UpdateGameInputModel gamescoreInfo);

        GameDto DeleteGame(DeleteGameInputModel gameInfo);
    }
}
