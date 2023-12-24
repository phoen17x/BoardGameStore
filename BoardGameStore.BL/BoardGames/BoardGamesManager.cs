using AutoMapper;
using BoardGameStore.BL.BoardGames.Entities;
using BoardGameStore.DataAccess;
using BoardGameStore.DataAccess.Entities;

namespace BoardGameStore.BL.BoardGames;

public class BoardGamesManager : IBoardGamesManager
{
    private readonly IRepository<BoardGameEntity> _boardGameRepository;
    private readonly IMapper _mapper;

    public BoardGamesManager(IRepository<BoardGameEntity> boardGameRepository, IMapper mapper)
    {
        _boardGameRepository = boardGameRepository;
        _mapper = mapper;
    }
    
    public BoardGameModel CreateBoardGame(CreateBoardGameModel model)
    {
        var entity = _mapper.Map<BoardGameEntity>(model);

        _boardGameRepository.Save(entity);

        return _mapper.Map<BoardGameModel>(model);
    }

    public void DeleteBoardGame(Guid id)
    {
        var entity = _boardGameRepository.GetById(id);

        if (entity is null)
        {
            throw new ArgumentException("Game not found");
        }
        
        _boardGameRepository.Delete(entity);
    }

    public BoardGameModel UpdateBoardGame(Guid id, UpdateBoardGameModel model)
    {
        var entity = _boardGameRepository.GetById(id);

        if (entity is null)
        {
            throw new ArgumentException("Game not found");
        }

        entity.Title = model.Title;
        entity.Price = model.Price;
        entity.AgeLimit = model.AgeLimit;
        entity.PlayersMin = model.PlayersMin;
        entity.PlayersMax = model.PlayersMax;

        _boardGameRepository.Save(entity);

        return _mapper.Map<BoardGameModel>(entity);
    }
}