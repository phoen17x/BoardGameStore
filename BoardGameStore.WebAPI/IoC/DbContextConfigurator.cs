using BoardGameStore.DataAccess;
using BoardGameStore.WebAPI.Settings;
using Microsoft.EntityFrameworkCore;

namespace BoardGameStore.WebAPI.IoC;

public static class DbContextConfigurator
{
    public static void ConfigureService(IServiceCollection services, BoardGameStoreSettings settings)
    {
        services.AddDbContextFactory<BoardGameStoreDbContext>(
            options => options.UseSqlServer(settings.BoardGameStoreDbContextConnectionString),
            ServiceLifetime.Scoped);
    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<BoardGameStoreDbContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate();
    }
}