using BoardGameStore.BL.Mapper;
using BoardGameStore.WebAPI.Mapper;

namespace BoardGameStore.WebAPI.IoC;

public static class MapperConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile<UsersBLProfile>();
            config.AddProfile<BoardGamesBLProfile>();
            config.AddProfile<UsersWebAPIProfile>();
            config.AddProfile<BoardGamesWebAPIProfile>();
        });
    }
}