namespace FootballLeague.Web.AutoMapperProfiles
{
    using FootballLeague.Application.Common.Models.DTOs;
    using FootballLeague.Domain.Entities;

    public class TeamScoreProfile : AutoMapper.Profile
    {
        public TeamScoreProfile()
        {
            this.CreateMap<TeamScore, TeamScoreDto>();
        }
    }
}