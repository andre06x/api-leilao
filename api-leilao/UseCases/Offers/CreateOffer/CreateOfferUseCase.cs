using api_leilao.Communication.Requests;
using api_leilao.Contracts;
using api_leilao.Entites;
using api_leilao.Repositories;
using api_leilao.Services;

namespace api_leilao.UseCases.Offers.CreateOffer
{
    public class CreateOfferUseCase
    {
        private readonly LoggedUser _loggedUser;
        private readonly IOfferRepository _repository;
        public CreateOfferUseCase(LoggedUser loggedUser, IOfferRepository repository) { 
            _loggedUser = loggedUser;
            _repository = repository;
         }
        public int Execute(int itemId, RequestCreateOffer request)
        {

            var user = _loggedUser.User();
            var offer = new Offer
            {
                CreatedOn = DateTime.Now,
                ItemId = itemId,
                Price = request.Price,
                UserId = user.Id,
            };

            _repository.Add(offer);
            return offer.Id;
        }
    }
}
