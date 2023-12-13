using BrewHub.Application.Features.DtoModels;
using MediatR;

namespace BrewHub.Application.Features.Commands
{
    // Request and Handler for AddNewBeerAsync
    public class AddNewBeerCommand : IRequest<BeerDto>
    {
        public int BreweryId { get; set; }
        public BeerDto NewBeerDto { get; set; }
    }
}
