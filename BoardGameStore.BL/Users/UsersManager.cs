using AutoMapper;
using BoardGameStore.BL.Users.Entities;
using BoardGameStore.DataAccess;
using BoardGameStore.DataAccess.Entities;

namespace BoardGameStore.BL.Users;

public class UsersManager : IUsersManager
{
    private readonly IRepository<UserEntity> _userRepository;
    private readonly IMapper _mapper;

    public UsersManager(IRepository<UserEntity> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public UserModel CreateUser(CreateUserModel model)
    {
        var entity = _mapper.Map<UserEntity>(model);

        _userRepository.Save(entity);

        return _mapper.Map<UserModel>(model);
    }

    public void DeleteUser(Guid id)
    {
        var entity = _userRepository.GetById(id);

        if (entity is null)
        {
            throw new ArgumentException("User not found");
        }
        
        _userRepository.Delete(entity);
    }

    public UserModel UpdateUser(Guid id, UpdateUserModel model)
    {
        var entity = _userRepository.GetById(id);

        if (entity is null)
        {
            throw new ArgumentException("User not found");
        }

        entity.Username = model.Username;
        entity.FirstName = model.FirstName;
        entity.LastName = model.LastName;
        entity.PasswordHash = model.PasswordHash;
        entity.Email = model.Email;
        entity.Phone = model.Phone;

        _userRepository.Save(entity);

        return _mapper.Map<UserModel>(entity);
    }
}