namespace FootballLeague.Domain.Entities
{
    public class TeamsGames
    {
        public int Id { get; set; }

        public Team HomeTeam { get; set; }

        public Team GuestTeam { get; set; }

        public FootballGame Game { get; set; }
    }
}
