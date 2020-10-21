namespace FootballLeague.Application.Controllers
{
    using FootballLeague.Application.Common.Contracts;
    using FootballLeague.Application.Common.Models.DTOs;
    using FootballLeague.Application.Common.Models.InputModels;
    using FootballLeague.Application.Common.Models.InputModels.GameModels;
    using FootballLeague.Application.Filters;
    using FootballLeague.Domain.Entities;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Http;
    using System.Web.Http.Cors;

    [ActionHandleFilter]
    [ExceptionHandleFilter]
    [EnableCors(origins: "http://localhost:5000", headers: "*", methods: "*")]
    public class GamesController : ApiController
    {
        private readonly IGamesService gamesService;

        public GamesController(IGamesService gamesService)
        {
            this.gamesService = gamesService;
        }

        [HttpGet]
        [Route("api/Games/GetGameDetails")]
        public PlayedGameInfoDto GetGameDetails([FromUri][Required] int gameId)
        {
            return this.gamesService.GetGameById(gameId);
        }

        [HttpGet]
        [Route("api/Games/GetAllPlayedGames")]
        public List<PlayedGameInfoDto> GetAllPlayedGames()
        {
            return this.gamesService.GetAllPlayedGamesInfo();
        }

        [HttpPost]
        [Route("api/Games/RegisterGameInfo")]
        public GameDto RegisterGameInfo([Required] CreateGameInputModel gameInfo)
        {
            return this.gamesService.RegisterGameInfo(gameInfo);
        }

        [HttpPut]
        [Route("api/Games/UpdateGameScores")]
        public GameDto UpdateGameScores([Required] UpdateGameInputModel gameInfo)
        {
            return this.gamesService.UpdateGameScores(gameInfo);
        }

        [HttpPut]
        [Route("api/Games/DeleteGame")]
        public GameDto DeleteGame([Required] DeleteGameInputModel gameInfo)
        {
            return this.gamesService.DeleteGame(gameInfo);
        }
    }
}
