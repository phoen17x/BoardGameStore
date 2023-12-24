using BoardGameStore.DataAccess;
using BoardGameStore.DataAccess.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace BoardGameStore.UnitTests.Repository;

[TestFixture]
[Category("Integration")]
public class UserRepositoryTests : RepositoryTestsBaseClass
{
    [Test]
    public void GetAllUsersTest()
    {
        //prepare
        using var context = DbContextFactory.CreateDbContext();
        
        var users = new UserEntity[]
        {
            new UserEntity()
            {
                Username = "Test1",
                FirstName = "Test1",
                LastName = "Test1",
                PasswordHash = "Test1",
                Email = "Test1",
                Phone = "Test1",
                ExternalId = Guid.NewGuid()
            },
            new UserEntity()
            {
                Username = "Test2",
                FirstName = "Test2",
                LastName = "Test2",
                PasswordHash = "Test2",
                Email = "Test2",
                Phone = "Test2",
                ExternalId = Guid.NewGuid()
            }
        };
        
        context.Users.AddRange(users);
        context.SaveChanges();
        
        //execute
        var repository = new Repository<UserEntity>(DbContextFactory);
        var actualUsers = repository.GetAll();

        //assert        
        actualUsers.Should().BeEquivalentTo(users);
    }

    [Test]
    public void GetAllUsersWithFilterTest()
    {
        //prepare
        using var context = DbContextFactory.CreateDbContext();

        var users = new UserEntity[]
        {
            new UserEntity()
            {
                Username = "Test1",
                FirstName = "Test1",
                LastName = "Test1",
                PasswordHash = "Test1",
                Email = "Test1",
                Phone = "Test1",
                ExternalId = Guid.NewGuid()
            },
            new UserEntity()
            {
                Username = "Test2",
                FirstName = "Test2",
                LastName = "Test2",
                PasswordHash = "Test2",
                Email = "Test2",
                Phone = "Test2",
                ExternalId = Guid.NewGuid()
            }
        };
        
        context.Users.AddRange(users);
        context.SaveChanges();
        //execute

        var repository = new Repository<UserEntity>(DbContextFactory);
        var actualUsers = repository.GetAll(x => x.FirstName == "Test1").ToArray();

        //assert
        actualUsers.Should().BeEquivalentTo(users.Where(x => x.FirstName == "Test1"));
    }

    [Test]
    public void SaveNewUserTest()
    {
        //prepare
        using var context = DbContextFactory.CreateDbContext();

        //execute

        var user = new UserEntity()
        {
            Username = "Test1",
            FirstName = "Test1",
            LastName = "Test1",
            PasswordHash = "Test1",
            Email = "Test1",
            Phone = "Test1",
            ExternalId = Guid.NewGuid()
        };
        
        var repository = new Repository<UserEntity>(DbContextFactory);
        repository.Save(user);

        //assert
        var actualUser = context.Users.SingleOrDefault();
        actualUser.Should().BeEquivalentTo(user, options => options.Excluding(x => x.Id)
            .Excluding(x => x.ModificationTime)
            .Excluding(x => x.CreationTime)
            .Excluding(x => x.ExternalId));
        actualUser.Id.Should().NotBe(default);
        actualUser.ModificationTime.Should().NotBe(default);
        actualUser.CreationTime.Should().NotBe(default);
        actualUser.ExternalId.Should().NotBe(Guid.Empty);
    }

    [Test]
    public void UpdateUserTest()
    {
        //prepare
        using var context = DbContextFactory.CreateDbContext();

        var user = new UserEntity()
        {
            Username = "Test1",
            FirstName = "Test1",
            LastName = "Test1",
            PasswordHash = "Test1",
            Email = "Test1",
            Phone = "Test1",
            ExternalId = Guid.NewGuid()
        };
        
        context.Users.Add(user);
        context.SaveChanges();

        //execute

        user.FirstName = "new name1";
        user.LastName = "new name2";
        user.Username = "new name3";
        var repository = new Repository<UserEntity>(DbContextFactory);
        repository.Save(user);

        //assert
        var actualUser = context.Users.SingleOrDefault();
        actualUser.Should().BeEquivalentTo(user);
    }

    [Test]
    public void DeleteUserTest()
    {
        //prepare
        using var context = DbContextFactory.CreateDbContext();
        
        var user = new UserEntity()
        {
            Username = "Test1",
            FirstName = "Test1",
            LastName = "Test1",
            PasswordHash = "Test1",
            Email = "Test1",
            Phone = "Test1",
            ExternalId = Guid.NewGuid()
        };
        
        context.Users.Add(user);
        context.SaveChanges();

        //execute

        var repository = new Repository<UserEntity>(DbContextFactory);
        repository.Delete(user);

        //assert
        context.Users.Count().Should().Be(0);
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

    public void CleanUp()
    {
        using var context = DbContextFactory.CreateDbContext();
        
        context.Users.RemoveRange(context.Users);
        context.SaveChanges();
    }
}