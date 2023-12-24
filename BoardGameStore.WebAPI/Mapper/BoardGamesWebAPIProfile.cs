using AutoMapper;
using BoardGameStore.BL.BoardGames.Entities;
using BoardGameStore.WebAPI.Controllers.Entities;

namespace BoardGameStore.WebAPI.Mapper;

public class BoardGamesWebAPIProfile : Profile
{
    public BoardGamesWebAPIProfile()
    {
        CreateMap<BoardGamesFilter, BoardGameModelFilter>();
        CreateMap<CreateBoardGameRequest, CreateBoardGameModel>();
        CreateMap<UpdateBoardGameRequest, UpdateBoardGameModel>();
    }
}