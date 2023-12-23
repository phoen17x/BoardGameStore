using BoardGameStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoardGameStore.DataAccess;

public class BoardGameStoreDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<UserRoleEntity> UserRoles { get; set; }
        public DbSet<BoardGameEntity> BoardGames { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<GameGenreEntity> GameGenres { get; set; }
        public DbSet<CartItemEntity> CartItems { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderItemEntity> OrderItems { get; set; }
        public DbSet<StoreInfoEntity> StoreInfos { get; set; }

        public BoardGameStoreDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<UserEntity>().HasIndex(x => x.ExternalId).IsUnique();
            
            modelBuilder.Entity<RoleEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<RoleEntity>().HasIndex(x => x.ExternalId).IsUnique();
            
            modelBuilder.Entity<UserRoleEntity>().HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<UserRoleEntity>().HasOne(x => x.User)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.UserId);
            modelBuilder.Entity<UserRoleEntity>().HasOne(x => x.Role)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.RoleId);
            
            modelBuilder.Entity<BoardGameEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<BoardGameEntity>().HasIndex(x => x.ExternalId).IsUnique();
            
            modelBuilder.Entity<GenreEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<GenreEntity>().HasIndex(x => x.ExternalId).IsUnique();
            
            modelBuilder.Entity<GameGenreEntity>().HasKey(x => new { x.GameId, x.GenreId });
            modelBuilder.Entity<GameGenreEntity>().HasOne(x => x.BoardGame)
                .WithMany(x => x.GameGenres)
                .HasForeignKey(x => x.GameId);
            modelBuilder.Entity<GameGenreEntity>().HasOne(x => x.Genre)
                .WithMany(x => x.GameGenres)
                .HasForeignKey(x => x.GenreId);
            
            modelBuilder.Entity<CartItemEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<CartItemEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<CartItemEntity>().HasOne(x => x.User)
                .WithMany(x => x.CartItems)
                .HasForeignKey(x => x.UserId);
            modelBuilder.Entity<CartItemEntity>().HasOne(x => x.BoardGame)
                .WithMany()
                .HasForeignKey(x => x.GameId);
            
            modelBuilder.Entity<OrderEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<OrderEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<OrderEntity>().HasOne(x => x.User)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.UserId);
            
            modelBuilder.Entity<OrderItemEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<OrderItemEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<OrderItemEntity>().HasOne(x => x.Order)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.OrderId);
            modelBuilder.Entity<OrderItemEntity>().HasOne(x => x.BoardGame)
                .WithMany()
                .HasForeignKey(x => x.GameId);
            
            modelBuilder.Entity<StoreInfoEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<StoreInfoEntity>().HasIndex(x => x.ExternalId).IsUnique();
        }
    }