namespace FootballLeague.Application.Common.Models.DTOs
{
    using FootballLeague.Application.Common.Abstracts;

    public class PlayedGameInfoDto : GameAbstract
    {
        public string HomeTeamName { get; set; }

        public string GuestTeamName { get; set; }
    }
}
