using api_leilao.Entites;
using api_leilao.Repositories;
using Microsoft.EntityFrameworkCore;

namespace api_leilao.UseCases.Leiloes.GetCurrent
{
    public class GetCurrentLeiloesUseCase
    {
        public Auction Execute()
        {
            var repository = new AuctionDbContext();

            return repository.Auctions.Include(auction => auction.Items).First();
        }
    }
}
