using BrewHub.Application.Features.Commands;
using BrewHub.Application.Features.DtoModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BrewHub.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BrewHubController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrewHubController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("brewery/{breweryId}/beers")]
        public async Task<IActionResult> GetAllBeersByBrewery(int breweryId)
        {
            var result = await _mediator.Send(new GetAllBeersByBreweryQuery { BreweryId = breweryId });
            return Ok(result);
        }

        [HttpPost("brewery/{breweryId}/beers")]
        public async Task<IActionResult> AddNewBeer(int breweryId, [FromBody] BeerDto newBeerDto)
        {
            var result = await _mediator.Send(new AddNewBeerCommand { BreweryId = breweryId, NewBeerDto = newBeerDto });
            return CreatedAtAction(nameof(GetAllBeersByBrewery), new { breweryId }, result);
        }

        [HttpDelete("beers/{beerId}")]
        public async Task<IActionResult> DeleteBeer(int beerId)
        {
            await _mediator.Send(new DeleteBeerCommand { BeerId = beerId });
            return NoContent();
        }

        [HttpPost("wholesaler/{wholesalerId}/sale")]
        public async Task<IActionResult> AddSaleToWholesaler(int wholesalerId, [FromBody] AddSaleToWholesalerCommand command)
        {
            command.WholesalerId = wholesalerId;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("wholesaler/{wholesalerId}/beer/{beerId}")]
        public async Task<IActionResult> UpdateRemainingQuantity(int wholesalerId, int beerId, [FromBody] UpdateRemainingQuantityCommand command)
        {
            command.WholesalerId = wholesalerId;
            command.BeerId = beerId;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPost("wholesaler/{wholesalerId}/quote")]
        public async Task<IActionResult> RequestQuote(int wholesalerId, [FromBody] QuoteRequestDto requestDto)
        {
            var result = await _mediator.Send(new RequestQuoteQuery { WholesalerId = wholesalerId, RequestDto = requestDto });
            return Ok(result);
        }

        //[HttpPost("wholesaler/{wholesalerId}/quote/generate")]
        //public async Task<IActionResult> GenerateQuote(int wholesalerId, [FromBody] QuoteRequestDto requestDto)
        //{
        //    var result = await _mediator.Send(new GenerateQuoteQuery { WholesalerId = wholesalerId, RequestDto = requestDto });
        //    return Ok(result);
        //}
    }
}
