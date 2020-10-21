namespace FootballLeague.Web.AutoMapperProfiles
{
    using FootballLeague.Application.Common.Models.DTOs;
    using FootballLeague.Domain.Entities;

    public class TeamsGamesProfile : AutoMapper.Profile
    {
        public TeamsGamesProfile()
        {
            this.CreateMap<TeamsGames, GameDto>()
                .ForMember(t => t.GuestTeamResult, opt => opt.MapFrom(g => g.Game.GuestTeamResult))
                .ForMember(t => t.HomeTeamResult, opt => opt.MapFrom(g => g.Game.HomeTeamResult));
        }
    }
}