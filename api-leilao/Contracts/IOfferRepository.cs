using api_leilao.Entites;

namespace api_leilao.Contracts
{
    public interface IOfferRepository
    {
        void Add(Offer offer);
    }
}
