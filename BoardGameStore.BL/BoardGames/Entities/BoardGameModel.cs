namespace BoardGameStore.BL.BoardGames.Entities;

public class BoardGameModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public int AgeLimit { get; set; }
    public int PlayersMin { get; set; }
    public int PlayersMax { get; set; }
}