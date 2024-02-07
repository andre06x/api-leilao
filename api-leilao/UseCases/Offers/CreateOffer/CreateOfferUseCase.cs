using api_leilao.Communication.Requests;
using api_leilao.Entites;
using api_leilao.Repositories;
using api_leilao.Services;

namespace api_leilao.UseCases.Offers.CreateOffer
{
    public class CreateOfferUseCase
    {
        private readonly LoggedUser _loggedUser;

        public CreateOfferUseCase(LoggedUser loggedUser) => _loggedUser = loggedUser;
        public int Execute(int itemId, RequestCreateOffer request)
        {
            var repository = new AuctionDbContext();

            var user = _loggedUser.User();
            var offer = new Offer
            {
                CreatedOn = DateTime.Now,
                ItemId = itemId,
                Price = request.Price,
                UserId = user.Id,
            };
            repository.Offers.Add(offer);
            repository.SaveChanges();

            return offer.Id;
        }
    }
}
