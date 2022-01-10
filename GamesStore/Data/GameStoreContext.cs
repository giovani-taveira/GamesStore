using GamesStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamesStore.Data
{
    public class GameStoreContext : DbContext
    {

        public GameStoreContext(DbContextOptions<GameStoreContext> option)
            : base(option) { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Promocao> Promocao { get; set;}
    }
}
