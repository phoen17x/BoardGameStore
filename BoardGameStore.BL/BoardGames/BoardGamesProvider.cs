using AutoMapper;
using BoardGameStore.BL.BoardGames.Entities;
using BoardGameStore.DataAccess;
using BoardGameStore.DataAccess.Entities;

namespace BoardGameStore.BL.BoardGames;

public class BoardGamesProvider : IBoardGamesProvider
{
    private readonly IRepository<BoardGameEntity> _boardGameRepository;
    private readonly IMapper _mapper;

    public BoardGamesProvider(IRepository<BoardGameEntity> boardGameRepository, IMapper mapper)
    {
        _boardGameRepository = boardGameRepository;
        _mapper = mapper;
    }
    
    public BoardGameModel GetBoardGameInfo(Guid gameId)
    {
        var game = _boardGameRepository.GetById(gameId);

        if (game is null)
        {
            throw new ArgumentException("Game not found");
        }

        return _mapper.Map<BoardGameModel>(game);
    }
    
    public IEnumerable<BoardGameModel> GetAllBoardGames()
    {
        var games = _boardGameRepository.GetAll();

        return _mapper.Map<IEnumerable<BoardGameModel>>(games);
    }

    public IEnumerable<BoardGameModel> GetAllBoardGamesWithFilter(BoardGameModelFilter filter)
    {
        var title = filter?.Title;
        var price = filter?.Price;
        var ageLimit = filter?.AgeLimit;
        var playersMin = filter?.PlayersMin;
        var playersMax = filter?.PlayersMax;

        var games = _boardGameRepository.GetAll(
            x => x.Title == title && 
                 x.Price <= price &&
                 x.AgeLimit <= ageLimit &&
                 x.PlayersMin >= playersMin &&
                 x.PlayersMax <= playersMax);

        return _mapper.Map<IEnumerable<BoardGameModel>>(games);
    }
}