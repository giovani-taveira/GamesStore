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

            modelBuilder.Entity<Games>()
                .HasKey(e => e.GameId);

            modelBuilder.Entity<Promocao>()
                .HasKey(e => e.PromocaoId);

            modelBuilder.Entity<Usuario>()
                .HasKey(e => e.UsuarioId);

            modelBuilder.Entity<Carrinho>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Review>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Games>()
                .HasMany(c => c.Reviews)
                .WithOne()
                .HasForeignKey(c => c.GameId);

            modelBuilder.Entity<Usuario>()
                .HasOne(c => c.Carrinho)
                .WithOne(c => c.Usuario)
                .HasForeignKey<Carrinho>(c => c.UsuarioId);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Games)
                .WithOne()
                .HasForeignKey(e => e.UsuarioId);

        }

        public DbSet<Games> Games { get; set; }
        public DbSet<Promocao> Promocao { get; set;}
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
