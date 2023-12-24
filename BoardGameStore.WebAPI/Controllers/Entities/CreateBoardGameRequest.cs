using System.ComponentModel.DataAnnotations;

namespace BoardGameStore.WebAPI.Controllers.Entities;

public class CreateBoardGameRequest
{
    [Required]
    [MinLength(2)]
    public string Title { get; set; }
    
    [Required]
    public decimal Price { get; set; }
    
    [Required]
    public int AgeLimit { get; set; }
    
    [Required]
    public int PlayersMin { get; set; }
    
    [Required]
    public int PlayersMax { get; set; }
}