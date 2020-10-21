namespace FootballLeague.Application.Common.Abstracts
{
    using System.ComponentModel.DataAnnotations;

    public abstract class GameAbstract
    {
        [Required]
        public int Id { get; set; }

        public int HomeTeamResult { get; set; }

        public int GuestTeamResult { get; set; }
    }
}
