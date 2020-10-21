namespace FootballLeague.Application.Common.Models.InputModels.GameModels
{
    using FootballLeague.Application.Common.Abstracts;
    using System.ComponentModel.DataAnnotations;

    public class CreateGameInputModel : GameResultAbstract
    {
        [Required]
        public int HomeTeamId { get; set; }

        [Required]
        public int GuestTeamId { get; set; }
    }
}
