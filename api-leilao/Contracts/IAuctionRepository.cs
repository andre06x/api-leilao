using api_leilao.Entites;

namespace api_leilao.Contracts
{
    public interface IAuctionRepository
    {
        Auction? GetCurrent();

    }
}
