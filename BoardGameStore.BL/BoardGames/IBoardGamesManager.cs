using BoardGameStore.BL.BoardGames.Entities;

namespace BoardGameStore.BL.BoardGames;

public interface IBoardGamesManager
{
    BoardGameModel CreateBoardGame(CreateBoardGameModel model);
    void DeleteBoardGame(Guid id);
    BoardGameModel UpdateBoardGame(Guid id, UpdateBoardGameModel model);
}