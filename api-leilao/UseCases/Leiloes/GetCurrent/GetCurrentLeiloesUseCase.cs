using api_leilao.Contracts;
using api_leilao.Entites;
using api_leilao.Repositories;
using Microsoft.EntityFrameworkCore;

namespace api_leilao.UseCases.Leiloes.GetCurrent
{
    public class GetCurrentLeiloesUseCase
    {
        private readonly IAuctionRepository _repository;

        public GetCurrentLeiloesUseCase(IAuctionRepository repository) => _repository = repository;
        public Auction Execute()
        {
            return _repository.GetCurrent();
        }
    }
}
