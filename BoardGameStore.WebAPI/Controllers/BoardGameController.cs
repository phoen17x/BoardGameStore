using AutoMapper;
using BoardGameStore.BL.BoardGames;
using BoardGameStore.BL.BoardGames.Entities;
using BoardGameStore.BL.Users;
using BoardGameStore.BL.Users.Entities;
using BoardGameStore.WebAPI.Controllers.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameStore.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BoardGameController : Controller
{
    private readonly IBoardGamesProvider _boardGamesProvider;
    private readonly IBoardGamesManager _boardGamesManager;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public BoardGameController(
        IBoardGamesProvider boardGamesProvider, 
        IBoardGamesManager boardGamesManager, 
        IMapper mapper, 
        ILogger logger)
    {
        _boardGamesManager = boardGamesManager;
        _boardGamesProvider = boardGamesProvider;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetAllBoardGames()
    {
        var games = _boardGamesProvider.GetAllBoardGames();
        return Ok(new BoardGamesListResponse()
        {
            BoardGames = games.ToList()
        });
    }

    [HttpGet]
    [Route("filter")]
    public IActionResult GetFilteredBoardGames([FromQuery] BoardGamesFilter filter)
    {
        var games = _boardGamesProvider.GetAllBoardGamesWithFilter(_mapper.Map<BoardGameModelFilter>(filter));
        return Ok(new BoardGamesListResponse()
        {
            BoardGames = games.ToList()
        });
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetBoardGameInfo([FromRoute] Guid id)
    {
        try
        {
            var game = _boardGamesProvider.GetBoardGameInfo(id);
            return Ok(game);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult CreateBoardGame([FromBody] CreateBoardGameRequest request)
    {
        try
        {
            var game = _boardGamesManager.CreateBoardGame(_mapper.Map<CreateBoardGameModel>(request));
            return Ok(game);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateBoardGameInfo([FromRoute] Guid id, UpdateBoardGameRequest request)
    {
        try
        {
            var game = _boardGamesManager.UpdateBoardGame(id, _mapper.Map<UpdateBoardGameModel>(request));
            return Ok(game);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteBoardGame([FromRoute] Guid id)
    {
        try
        {
            _boardGamesManager.DeleteBoardGame(id);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);

        }
    }
}
