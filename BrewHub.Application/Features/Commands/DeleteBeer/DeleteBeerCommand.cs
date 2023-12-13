using MediatR;

namespace BrewHub.Application.Features.Commands
{
    // Request and Handler for DeleteBeerAsync
    public class DeleteBeerCommand : IRequest
    {
        public int BeerId { get; set; }
    }
}
