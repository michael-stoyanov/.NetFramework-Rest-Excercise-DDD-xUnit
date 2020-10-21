namespace FootballLeague.Application.Common.Models
{
    using System.Collections.Generic;

    public class TeamDto
    {
        public string Name { get; set; }

        public List<int> Scores { get; set; }
    }
}
