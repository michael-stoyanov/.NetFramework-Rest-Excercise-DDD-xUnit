namespace FootballLeague.Web.AutoMapperProfiles
{
    using AutoMapper;
    using FootballLeague.Application.Common.Models.DTOs;
    using FootballLeague.Domain.Entities;
    using System.Linq;

    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            this.CreateMap<Team, TeamDto>()
                .ForMember(t => t.GuestGames, opt => opt.MapFrom(gg => gg.GuestGames))
                .ForMember(t => t.HomeGames, opt => opt.MapFrom(gg => gg.HomeGames));
                //.ForMember(t => t.GuestGames, opt => opt.MapFrom(t => t.GuestGames.Select(g => g.Game).ToList()))
                //.ForMember(t => t.GuestGames, opt => opt.MapFrom(t => t.HomeGames.Select(g => g.Game).ToList()));
        }
    }
}