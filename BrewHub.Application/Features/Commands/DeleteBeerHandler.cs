using BrewHub.Application.Contracts.Persistence;
using MediatR;

namespace BrewHub.Application.Features.Commands
{
    public class DeleteBeerHandler : IRequestHandler<DeleteBeerCommand>
    {
        private readonly IBreweryService _breweryService;

        public DeleteBeerHandler(IBreweryService breweryService)
        {
            _breweryService = breweryService;
        }

        public async Task<Unit> Handle(DeleteBeerCommand request, CancellationToken cancellationToken)
        {
            await _breweryService.DeleteBeerAsync(request.BeerId);
            return Unit.Value;
        }
    }
}
