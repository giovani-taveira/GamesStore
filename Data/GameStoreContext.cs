using GamesStore.Data.Validations;
using GamesStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamesStore.Data
{
    public class GameStoreContext : DbContext
    {

        public GameStoreContext(DbContextOptions<GameStoreContext> option)
            : base(option) 
        { 

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Configurations
            modelBuilder.ApplyConfiguration(new GameValidation());
            modelBuilder.ApplyConfiguration(new ReviewValidation());
            modelBuilder.ApplyConfiguration(new SaleValidations());
            modelBuilder.ApplyConfiguration(new UserValidation());
            #endregion

            #region Primary Keys
            modelBuilder.Entity<Games>()
                .HasKey(e => e.GameId);

            modelBuilder.Entity<Sale>()
                .HasKey(e => e.SaleId);

            modelBuilder.Entity<User>()
                .HasKey(e => e.UserId);

            modelBuilder.Entity<Cart>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<WishList>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Library>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Review>()
                .HasKey(e => e.Id);

            #endregion

            #region Froreign Keys
            modelBuilder.Entity<Games>()
                .HasMany(c => c.Reviews)
                .WithOne()
                .HasForeignKey(c => c.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne(c => c.Cart)
                .WithOne()
                .HasForeignKey<Cart>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne(c => c.WishList)
                .WithOne()
                .HasForeignKey<WishList>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne(c => c.Library)
                .WithOne()
                .HasForeignKey<Library>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Games)
                .WithOne()
                .HasForeignKey(e => e.UserId);
            #endregion

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Games> Games { get; set; }
        public DbSet<Sale> Sales { get; set;}
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<Library> Libraries { get; set; }
    }
}
