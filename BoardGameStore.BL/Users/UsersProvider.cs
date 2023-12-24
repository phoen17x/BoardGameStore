using AutoMapper;
using BoardGameStore.BL.Users.Entities;
using BoardGameStore.DataAccess;
using BoardGameStore.DataAccess.Entities;

namespace BoardGameStore.BL.Users;

public class UsersProvider : IUsersProvider
{
    private readonly IRepository<UserEntity> _userRepository;
    private readonly IMapper _mapper;

    public UsersProvider(IRepository<UserEntity> usersRepository, IMapper mapper)
    {
        _userRepository = usersRepository;
        _mapper = mapper;
    }

    public UserModel GetUserInfo(Guid userId)
    {
        var user = _userRepository.GetById(userId);

        if (user is null)
        {
            throw new ArgumentException("User not found");
        }

        return _mapper.Map<UserModel>(user);
    }

    public IEnumerable<UserModel> GetAllUsers()
    {
        var users = _userRepository.GetAll();

        return _mapper.Map<IEnumerable<UserModel>>(users);
    }

    public IEnumerable<UserModel> GetAllUsersWithFilter(UserModelFilter filter)
    {
        var firstName = filter?.FirstName;
        var lastName = filter?.LastName;


        var users = _userRepository.GetAll(x => x.FirstName == firstName && x.LastName == lastName);

        return _mapper.Map<IEnumerable<UserModel>>(users);
    }
}