using AutoMapper;
using BoardGameStore.BL.BoardGames.Entities;
using BoardGameStore.DataAccess.Entities;

namespace BoardGameStore.BL.Mapper;

public class BoardGamesBLProfile : Profile
{
    public BoardGamesBLProfile() 
    {
        CreateMap<BoardGameEntity, BoardGameModel>()
            .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId));

        CreateMap<CreateBoardGameModel, BoardGameEntity>()
            .ForMember(x => x.Id, y => y.Ignore())
            .ForMember(x => x.ExternalId, y => y.Ignore())
            .ForMember(x => x.CreationTime, y => y.Ignore())
            .ForMember(x => x.ModificationTime, y => y.Ignore());
    }
}