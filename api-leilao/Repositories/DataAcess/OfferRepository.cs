using api_leilao.Contracts;
using api_leilao.Entites;
using System;

namespace api_leilao.Repositories.DataAcess
{
    public class OfferRepository : IOfferRepository
    {
        private readonly AuctionDbContext _dbContext;
        public OfferRepository(AuctionDbContext dbContext) => _dbContext = dbContext;

        public void Add(Offer offer)
        {
            _dbContext.Offers.Add(offer);
            _dbContext.SaveChanges();
        }
    }
}
