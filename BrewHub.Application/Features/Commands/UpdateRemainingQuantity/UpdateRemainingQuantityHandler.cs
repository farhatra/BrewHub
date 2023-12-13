using BrewHub.Application.Contracts.Persistence;
using BrewHub.Application.Features.Commands.UpdateRemainingQuantity;
using FluentValidation;
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
            // Validate the request
            new UpdateRemainingQuantityCommandValidator().ValidateAndThrow(request);

            await _wholesalerService.UpdateRemainingQuantityAsync(request.WholesalerId, request.BeerId, request.NewQuantity);
            return Unit.Value;
        }
    }
}
