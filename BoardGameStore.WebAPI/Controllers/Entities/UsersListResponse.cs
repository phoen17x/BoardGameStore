using BoardGameStore.BL.Users.Entities;

namespace BoardGameStore.WebAPI.Controllers.Entities;

public class UsersListResponse
{
    public List<UserModel> Users { get; set; }
}