namespace FootballLeague.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class TeamScore
    {
        [Key]
        public int Id { get; set; }

        public Team Team { get; set; }

        public int TotalScore { get; set; }
    }
}
