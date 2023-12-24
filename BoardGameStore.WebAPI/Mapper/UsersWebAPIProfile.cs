using AutoMapper;
using BoardGameStore.BL.Users.Entities;
using BoardGameStore.WebAPI.Controllers.Entities;

namespace BoardGameStore.WebAPI.Mapper;

public class UsersWebAPIProfile : Profile
{
    public UsersWebAPIProfile()
    {
        CreateMap<UsersFilter, UserModelFilter>();
        CreateMap<CreateUserRequest, CreateUserModel>();
        CreateMap<UpdateUserRequest, UpdateUserModel>();
    }
}