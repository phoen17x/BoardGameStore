namespace BoardGameStore.WebAPI.Controllers.Entities;

public class BoardGamesFilter
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public int AgeLimit { get; set; }
    public int PlayersMin { get; set; }
    public int PlayersMax { get; set; }
}