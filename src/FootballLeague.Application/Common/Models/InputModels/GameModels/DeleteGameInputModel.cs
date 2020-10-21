namespace FootballLeague.Application.Common.Models.InputModels.GameModels
{
    using System.ComponentModel.DataAnnotations;

    public class DeleteGameInputModel
    {
        [Required]
        public int GameId { get; set; }
    }
}
