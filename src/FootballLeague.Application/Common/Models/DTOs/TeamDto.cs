namespace FootballLeague.Application.Common.Models.DTOs
{
    using System.Collections.Generic;

    public class TeamDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<GameDto> HomeGames { get; set; } = new List<GameDto>();

        public List<GameDto> GuestGames { get; set; } = new List<GameDto>();
    }
}
