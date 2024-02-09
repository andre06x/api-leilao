using api_leilao.Contracts;
using api_leilao.Entites;
using Microsoft.EntityFrameworkCore;

namespace api_leilao.Repositories.DataAcess
{
    public class AuctionRepository: IAuctionRepository
    {
        private readonly AuctionDbContext _dbContext;
        public AuctionRepository(AuctionDbContext dbContext) => _dbContext = dbContext;

        public Auction? GetCurrent()
        {
            return _dbContext.Auctions.Include(auction => auction.Items).First();

        }
    }
}
