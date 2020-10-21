namespace FootballLeague.Application.Common.Models.InputModels.TeamModels
{
    using System.ComponentModel.DataAnnotations;

    public class DeleteTeamInputModel
    {
        [Required]
        public int TeamId { get; set; }
    }
}
