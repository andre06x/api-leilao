using api_leilao.Communication.Requests;
using api_leilao.Filters;
using api_leilao.UseCases.Offers.CreateOffer;
using Microsoft.AspNetCore.Mvc;

namespace api_leilao.Controllers
{
    [ServiceFilter(typeof(AuthenticationUserAttribute))]
    public class OfferController : AuctionBaseController
    {
        [HttpPost()]
        [Route("{itemId}")]

        public IActionResult CreateOffer([FromRoute] int itemId, [FromBody] RequestCreateOffer request, [FromServices] CreateOfferUseCase useCase)
        {
            var id = useCase.Execute(itemId, request);
            return Created(string.Empty, id);
        }
    }
}
