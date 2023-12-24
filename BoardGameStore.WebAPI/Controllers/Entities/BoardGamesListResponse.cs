using BoardGameStore.BL.BoardGames.Entities;

namespace BoardGameStore.WebAPI.Controllers.Entities;

public class BoardGamesListResponse
{
    public List<BoardGameModel> BoardGames { get; set; }
}