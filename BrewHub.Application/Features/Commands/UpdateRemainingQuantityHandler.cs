using BrewHub.Application.Contracts.Persistence;
using MediatR;

namespace BrewHub.Application.Features.Commands
{
    public class UpdateRemainingQuantityHandler : IRequestHandler<UpdateRemainingQuantityCommand>
    {
        private readonly IWholesalerService _wholesalerService;

        public UpdateRemainingQuantityHandler(IWholesalerService wholesalerService)
        {
            _wholesalerService = wholesalerService;
        }

        public async Task<Unit> Handle(UpdateRemainingQuantityCommand request, CancellationToken cancellationToken)
        {
            await _wholesalerService.UpdateRemainingQuantityAsync(request.WholesalerId, request.BeerId, request.NewQuantity);
            return Unit.Value;
        }
    }
}
