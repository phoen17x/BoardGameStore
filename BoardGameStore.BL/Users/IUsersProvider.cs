using BoardGameStore.BL.Users.Entities;

namespace BoardGameStore.BL.Users;

public interface IUsersProvider
{
    IEnumerable<UserModel> GetAllUsers();
    IEnumerable<UserModel> GetAllUsersWithFilter(UserModelFilter filter);
    UserModel GetUserInfo(Guid userId);
}