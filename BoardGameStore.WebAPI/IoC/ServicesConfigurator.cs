using BoardGameStore.BL.BoardGames;
using BoardGameStore.BL.Users;
using BoardGameStore.DataAccess;

namespace BoardGameStore.WebAPI.IoC;

public class ServicesConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUsersProvider, UsersProvider>();
        services.AddScoped<IUsersManager, UsersManager>();
        services.AddScoped<IBoardGamesManager, BoardGamesManager>();
        services.AddScoped<IBoardGamesProvider, BoardGamesProvider>();
    }
}