using BoardGameStore.BL.BoardGames.Entities;

namespace BoardGameStore.BL.BoardGames;

public interface IBoardGamesProvider
{
    IEnumerable<BoardGameModel> GetAllBoardGames();
    IEnumerable<BoardGameModel> GetAllBoardGamesWithFilter(BoardGameModelFilter filter);
    BoardGameModel GetBoardGameInfo(Guid gameId);
}