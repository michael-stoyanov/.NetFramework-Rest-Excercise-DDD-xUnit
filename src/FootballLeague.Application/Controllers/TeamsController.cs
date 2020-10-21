namespace FootballLeague.Application.Controllers
{
    using FootballLeague.Application.Common.Contracts;
    using FootballLeague.Application.Common.Models.DTOs;
    using FootballLeague.Application.Common.Models.InputModels;
    using FootballLeague.Application.Common.Models.InputModels.TeamModels;
    using FootballLeague.Application.Common.Models.ResponseModels;
    using FootballLeague.Application.Filters;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Http;

    [ActionHandleFilter]
    [ExceptionHandleFilter]
    public class TeamsController : ApiController
    {
        private readonly ITeamService teamService;

        public TeamsController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        [HttpGet]
        [Route("api/Teams/GetAllTeams")]
        public TeamsListResponseModel GetAllTeams()
        {
            return new TeamsListResponseModel()
            {
                Teams = this.teamService.GetAllRegisteredTeams()
            };
        }

        [HttpGet]
        [Route("api/Teams/GetTeam")]
        public TeamDto GetTeam([FromUri][Required] int teamId)
        {
            return this.teamService.GetTeamById(teamId);
        }

        [HttpPost]
        [Route("api/Teams/CreateTeam")]
        public TeamDto CreateTeam([FromBody] CreateTeamInputModel teamInfo)
        {
            return this.teamService.CreateTeam(teamInfo);
        }


        [HttpPut]
        [Route("api/Teams/ChangeTeamName")]
        public TeamDto ChangeTeamName([FromBody] ChangeTeamNameInputModel inputParams)
        {
            return this.teamService.ChangeTeamName(inputParams);
        }

        [HttpDelete]
        [Route("api/Teams/DeregisterTeam")]
        public TeamDto DeregisterTeam([FromBody] DeleteTeamInputModel teamToDelete)
        => this.teamService.DeleteTeam(teamToDelete);
    }
}
