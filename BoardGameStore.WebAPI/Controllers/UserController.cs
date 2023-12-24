using AutoMapper;
using BoardGameStore.BL.Users;
using BoardGameStore.BL.Users.Entities;
using BoardGameStore.WebAPI.Controllers.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameStore.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private readonly IUsersProvider _usersProvider;
    private readonly IUsersManager _usersManager;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public UserController(
        IUsersProvider usersProvider, 
        IUsersManager usersManager, 
        IMapper mapper, 
        ILogger logger)
    {
        _usersManager = usersManager;
        _usersProvider = usersProvider;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var users = _usersProvider.GetAllUsers();
        return Ok(new UsersListResponse()
        {
            Users = users.ToList()
        });
    }

    [HttpGet]
    [Route("filter")]
    public IActionResult GetFilteredUsers([FromQuery] UsersFilter filter)
    {
        var users = _usersProvider.GetAllUsersWithFilter(_mapper.Map<UserModelFilter>(filter));
        return Ok(new UsersListResponse()
        {
            Users = users.ToList()
        });
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetUserInfo([FromRoute] Guid id)
    {
        try
        {
            var user = _usersProvider.GetUserInfo(id);
            return Ok(user);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] CreateUserRequest request)
    {
        try
        {
            var user = _usersManager.CreateUser(_mapper.Map<CreateUserModel>(request));
            return Ok(user);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateUserInfo([FromRoute] Guid id, UpdateUserRequest request)
    {
        try
        {
            var user = _usersManager.UpdateUser(id, _mapper.Map<UpdateUserModel>(request));
            return Ok(user);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteUser([FromRoute] Guid id)
    {
        try
        {
            _usersManager.DeleteUser(id);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);

        }
    }
}