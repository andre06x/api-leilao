using api_leilao.Entites;
using api_leilao.UseCases.Leiloes.GetCurrent;
using Microsoft.AspNetCore.Mvc;

namespace api_leilao.Controllers
{

    public class LeilaoController : AuctionBaseController
    {
        [HttpGet()]
        [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetCurrentAuction([FromServices] GetCurrentLeiloesUseCase useCase)
        {
            var result = useCase.Execute();

            if(result is null)
            {
                return NoContent();
            }
            return Ok(result);
        }


    }
}
