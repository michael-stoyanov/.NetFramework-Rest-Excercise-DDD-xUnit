namespace FootballLeague.Application.Controllers
{
    using FootballLeague.Application.Common.Contracts;
    using FootballLeague.Application.Common.Models.DTOs;
    using FootballLeague.Application.Common.Models.InputModels.TeamModels;
    using FootballLeague.Application.Common.Models.ResponseModels;
    using FootballLeague.Application.Filters;
    using System;
    using System.Collections.Generic;
    using System.Web.Http;

    [ActionHandleFilter]
    [ExceptionHandleFilter]
    public class RankingsController : ApiController
    {
        private readonly IRankingsService rankingsService;

        public RankingsController(IRankingsService rankingsService)
        {
            this.rankingsService = rankingsService;
        }

        [HttpGet]
        [Route("api/Rankings/GetTeamScore")]
        public TeamScoreResponseModel GetTeamScore([FromUri]int teamId)
        {
            return new TeamScoreResponseModel() { TeamTotalScore = this.rankingsService.GetTeamTotalScore(teamId) };
        }

        [HttpGet]
        [Route("api/Rankings/GetTopTenTeams")]
        public List<TeamDto> GetTeamScore()
        {
            return this.rankingsService.GetTopTenTeams();
        }

        [HttpGet]
        [Route("api/Rankings/GetChampionshipWinner")]
        public TeamDto GetChampionshipWinner()
        {
            return this.rankingsService.GetChampionshipWinner();
        }
    }
}
