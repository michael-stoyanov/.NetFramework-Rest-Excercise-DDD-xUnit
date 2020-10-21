namespace FootballLeague.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class FootballGame
    {
        [Key]
        public int Id { get; set; }

        public int HomeTeamResult { get; set; }

        public int GuestTeamResult { get; set; }
    }
}
