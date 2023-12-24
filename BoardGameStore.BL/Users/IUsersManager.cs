using BoardGameStore.BL.Users.Entities;

namespace BoardGameStore.BL.Users;

public interface IUsersManager
{
    UserModel CreateUser(CreateUserModel model);
    void DeleteUser(Guid id);
    UserModel UpdateUser(Guid id, UpdateUserModel model);
}