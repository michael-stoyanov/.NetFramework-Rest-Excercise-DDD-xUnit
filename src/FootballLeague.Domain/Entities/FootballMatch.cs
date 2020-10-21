namespace FootballLeague.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class FootballMatch
    {
        [Key]
        public int Id { get; set; }

        public Team Home { get; set; }

        public Team Guest { get; set; }

        public int HomeTeamResult { get; set; }

        public int GuestTeamResult { get; set; }
    }
}
