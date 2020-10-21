namespace FootballLeague.Application.Common.Models.ResponseModels
{
    using FootballLeague.Application.Common.Models.DTOs;
    using System.Collections.Generic;

    public class TeamsListResponseModel
    {
        public ICollection<TeamDto> Teams { get; set; }
    }
}
