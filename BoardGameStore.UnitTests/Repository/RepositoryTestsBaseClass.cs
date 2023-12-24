using BoardGameStore.DataAccess;
using BoardGameStore.WebAPI.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BoardGameStore.UnitTests.Repository;

public class RepositoryTestsBaseClass
{
    protected readonly BoardGameStoreSettings Settings;
    protected readonly IDbContextFactory<BoardGameStoreDbContext> DbContextFactory;
    protected readonly IServiceProvider ServiceProvider;
    
    public RepositoryTestsBaseClass()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        Settings = BoardGameStoreSettingsReader.Read(configuration);
        ServiceProvider = ConfigureServiceProvider();

        DbContextFactory = ServiceProvider.GetRequiredService<IDbContextFactory<BoardGameStoreDbContext>>();
    }

    private IServiceProvider ConfigureServiceProvider()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDbContextFactory<BoardGameStoreDbContext>(
            options => options.UseSqlServer(Settings.BoardGameStoreDbContextConnectionString),
            ServiceLifetime.Scoped);
        
        return serviceCollection.BuildServiceProvider();
    }
}