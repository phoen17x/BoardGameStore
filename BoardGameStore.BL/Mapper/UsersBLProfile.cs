using AutoMapper;
using BoardGameStore.BL.Users.Entities;
using BoardGameStore.DataAccess.Entities;

namespace BoardGameStore.BL.Mapper;

public class UsersBLProfile : Profile
{
    public UsersBLProfile() 
    {
        CreateMap<UserEntity, UserModel>()
            .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId));

        CreateMap<CreateUserModel, UserEntity>()
            .ForMember(x => x.Id, y => y.Ignore())
            .ForMember(x => x.ExternalId, y => y.Ignore())
            .ForMember(x => x.CreationTime, y => y.Ignore())
            .ForMember(x => x.ModificationTime, y => y.Ignore());
    }

}