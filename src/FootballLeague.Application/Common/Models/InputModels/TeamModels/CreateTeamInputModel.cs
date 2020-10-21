namespace FootballLeague.Application.Common.Models.InputModels.TeamModels
{
    using System.ComponentModel.DataAnnotations;

    public class CreateTeamInputModel
    {
        [Required]
        public string TeamName { get; set; }
    }
}
