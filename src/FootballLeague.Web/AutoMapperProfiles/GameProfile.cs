namespace FootballLeague.Web.AutoMapperProfiles
{
    using FootballLeague.Application.Common.Models.DTOs;
    using FootballLeague.Domain.Entities;

    public class GameProfile : AutoMapper.Profile
    {
        public GameProfile()
        {
            this.CreateMap<FootballGame, GameDto>();
        }
    }
}