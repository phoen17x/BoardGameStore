using BoardGameStore.DataAccess;
using BoardGameStore.DataAccess.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace BoardGameStore.UnitTests.Repository;

[TestFixture]
[Category("Integration")]
public class BoardGameRepositoryTests : RepositoryTestsBaseClass
{
    [Test]
    public void GetAllBoardGamesTest()
    {
        // prepare
        using var context = DbContextFactory.CreateDbContext();
        
        var boardGames = new BoardGameEntity[]
        {
            new BoardGameEntity()
            {
                Title = "Monopoly",
                Price = 19.99m,
                AgeLimit = 8,
                PlayersMin = 2,
                PlayersMax = 6,
                ExternalId = Guid.NewGuid()
            },
            new BoardGameEntity()
            {
                Title = "Catan",
                Price = 29.99m,
                AgeLimit = 10,
                PlayersMin = 3,
                PlayersMax = 4,
                ExternalId = Guid.NewGuid()
            }
        };
        
        context.BoardGames.AddRange(boardGames);
        context.SaveChanges();
        
        // execute
        var repository = new Repository<BoardGameEntity>(DbContextFactory);
        var actualBoardGames = repository.GetAll();

        // assert        
        actualBoardGames.Should().BeEquivalentTo(boardGames);
    }

    [Test]
    public void GetAllBoardGamesWithFilterTest()
    {
        // prepare
        using var context = DbContextFactory.CreateDbContext();

        var boardGames = new BoardGameEntity[]
        {
            new BoardGameEntity()
            {
                Title = "Monopoly",
                Price = 19.99m,
                AgeLimit = 8,
                PlayersMin = 2,
                PlayersMax = 6,
                ExternalId = Guid.NewGuid()
            },
            new BoardGameEntity()
            {
                Title = "Catan",
                Price = 29.99m,
                AgeLimit = 10,
                PlayersMin = 3,
                PlayersMax = 4,
                ExternalId = Guid.NewGuid()
            }
        };
        
        context.BoardGames.AddRange(boardGames);
        context.SaveChanges();
        
        // execute
        var repository = new Repository<BoardGameEntity>(DbContextFactory);
        var actualBoardGames = repository.GetAll(x => x.PlayersMax > 4).ToArray();

        // assert
        actualBoardGames.Should().BeEquivalentTo(boardGames.Where(x => x.PlayersMax > 4));
    }

    [Test]
    public void SaveNewBoardGameTest()
    {
        // prepare
        using var context = DbContextFactory.CreateDbContext();

        // execute
        var boardGame = new BoardGameEntity()
        {
            Title = "Risk",
            Price = 34.99m,
            AgeLimit = 10,
            PlayersMin = 2,
            PlayersMax = 6,
            ExternalId = Guid.NewGuid()
        };
        
        var repository = new Repository<BoardGameEntity>(DbContextFactory);
        repository.Save(boardGame);

        // assert
        var actualBoardGame = context.BoardGames.SingleOrDefault();
        actualBoardGame.Should().BeEquivalentTo(boardGame, options => options.Excluding(x => x.Id));
        actualBoardGame.Id.Should().NotBe(default);
    }

    [Test]
    public void UpdateBoardGameTest()
    {
        // prepare
        using var context = DbContextFactory.CreateDbContext();

        var boardGame = new BoardGameEntity()
        {
            Title = "Monopoly",
            Price = 19.99m,
            AgeLimit = 8,
            PlayersMin = 2,
            PlayersMax = 6,
            ExternalId = Guid.NewGuid()
        };
        
        context.BoardGames.Add(boardGame);
        context.SaveChanges();

        // execute
        boardGame.Title = "Monopoly: Ultimate Banking Edition";
        boardGame.Price = 24.99m;
        var repository = new Repository<BoardGameEntity>(DbContextFactory);
        repository.Save(boardGame);

        // assert
        var actualBoardGame = context.BoardGames.SingleOrDefault();
        actualBoardGame.Should().BeEquivalentTo(boardGame);
    }

    [Test]
    public void DeleteBoardGameTest()
    {
        // prepare
        using var context = DbContextFactory.CreateDbContext();
        
        var boardGame = new BoardGameEntity()
        {
            Title = "Monopoly",
            Price = 19.99m,
            AgeLimit = 8,
            PlayersMin = 2,
            PlayersMax = 6,
            ExternalId = Guid.NewGuid()
        };
        
        context.BoardGames.Add(boardGame);
        context.SaveChanges();

        // execute
        var repository = new Repository<BoardGameEntity>(DbContextFactory);
        repository.Delete(boardGame);

        // assert
        context.BoardGames.Count().Should().Be(0);
    }

    [SetUp]
    public void SetUp()
    {
        CleanUp();
    }

    [TearDown]
    public void TearDown()
    {
        CleanUp();
    }

    private void CleanUp()
    {
        using var context = DbContextFactory.CreateDbContext();
        
        context.BoardGames.RemoveRange(context.BoardGames);
        context.SaveChanges();
    }
}
