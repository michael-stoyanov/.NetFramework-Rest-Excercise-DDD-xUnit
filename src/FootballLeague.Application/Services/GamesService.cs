namespace FootballLeague.Application.Services
{
    using AutoMapper;
    using FootballLeague.Application.Common.Contracts;
    using FootballLeague.Application.Common.Models.DTOs;
    using FootballLeague.Application.Common.Models.InputModels;
    using FootballLeague.Domain.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using FootballLeague.Application.Common.Models.InputModels.GameModels;
    using FootballLeague.Application.Common.Enums;

    public class GamesService : IGamesService
    {
        private readonly IGamesRepository gamesRepository;
        private readonly IRankingsService rankingsService;
        private readonly IMapper mapper;

        public GamesService(IGamesRepository gamesRepository, IRankingsService rankingsService, IMapper mapper)
        {
            this.gamesRepository = gamesRepository;
            this.rankingsService = rankingsService;
            this.mapper = mapper;
        }

        public PlayedGameInfoDto GetGameById(int gameId)
        {
            var gameInfo = this.gamesRepository.GetGameInfoById(gameId);

            return new PlayedGameInfoDto()
            {
                Id = gameInfo.Game.Id,
                GuestTeamName = gameInfo.GuestTeam.Name,
                HomeTeamName = gameInfo.HomeTeam.Name,
                GuestTeamResult = gameInfo.Game.GuestTeamResult,
                HomeTeamResult = gameInfo.Game.HomeTeamResult
            };
        }

        public List<PlayedGameInfoDto> GetAllPlayedGamesInfo()
        {
            var playedGames = this.gamesRepository.GetAllPlayedGames();

            if (playedGames is null)
                throw new ArgumentException("There are no registered games so far in the championship.");

            return playedGames.Select(g => new PlayedGameInfoDto()
            {
                GuestTeamName = g.GuestTeam.Name,
                HomeTeamName = g.HomeTeam.Name,
                GuestTeamResult = g.Game.GuestTeamResult,
                HomeTeamResult = g.Game.HomeTeamResult
            }).ToList();
        }

        public GameDto RegisterGameInfo(CreateGameInputModel gameInfo)
        {
            var registeredGameInfo = this.gamesRepository.RegisterGame(gameInfo.HomeTeamId, gameInfo.GuestTeamId, gameInfo.HomeTeamResult, gameInfo.GuestTeamResult);

            if (gameInfo.HomeTeamResult > gameInfo.GuestTeamResult)
            {
                this.rankingsService.AddTeamScoreById(gameInfo.HomeTeamId, (int)GameResultScore.Win);
            }
            else if (gameInfo.GuestTeamResult > gameInfo.HomeTeamResult)
            {
                this.rankingsService.AddTeamScoreById(gameInfo.GuestTeamId, (int)GameResultScore.Win);
            }
            else
            {
                this.rankingsService.AddTeamScoreById(gameInfo.GuestTeamId, (int)GameResultScore.Draw);
                this.rankingsService.AddTeamScoreById(gameInfo.HomeTeamId, (int)GameResultScore.Draw);
            }

            return this.mapper.Map<GameDto>(registeredGameInfo);
        }

        public GameDto UpdateGameScores(UpdateGameInputModel gamescoreInfo)
        {
            var gameInfo = this.gamesRepository.UpdateGameScores(gamescoreInfo.Id, gamescoreInfo.HomeTeamResult, gamescoreInfo.GuestTeamResult);

            return this.mapper.Map<GameDto>(gameInfo);
        }

        public GameDto DeleteGame(DeleteGameInputModel gameInfo)
        {
            var deletedGame = this.gamesRepository.DeleteGame(gameInfo.GameId);

            return this.mapper.Map<GameDto>(deletedGame);
        }
    }
}
