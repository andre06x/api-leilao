using api_leilao.Entites;
using Microsoft.EntityFrameworkCore;

namespace api_leilao.Repositories
{
    public class AuctionDbContext: DbContext
    {
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\andre\\Downloads\\leilaoDbNLW.db");
        }
    }
}
