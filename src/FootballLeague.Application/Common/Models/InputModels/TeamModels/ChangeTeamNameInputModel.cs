namespace FootballLeague.Application.Common.Models.InputModels.TeamModels
{
    using System.ComponentModel.DataAnnotations;

    public class ChangeTeamNameInputModel
    {
        [Required]
        public int TeamId { get; set; }

        [Required]
        public string NewTeamName { get; set; }
    }
}
