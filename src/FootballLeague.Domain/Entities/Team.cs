namespace FootballLeague.Domain.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Team
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<TeamsGames> HomeGames { get; set; } = new List<TeamsGames>();

        public ICollection<TeamsGames> GuestGames { get; set; } = new List<TeamsGames>();
    }
}
