using api_leilao.Entites;
using Microsoft.EntityFrameworkCore;

namespace api_leilao.Repositories
{
    public class AuctionDbContext: DbContext
    {
        public AuctionDbContext(DbContextOptions options) : base(options){ }


        public DbSet<Auction> Auctions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }

    }
}
