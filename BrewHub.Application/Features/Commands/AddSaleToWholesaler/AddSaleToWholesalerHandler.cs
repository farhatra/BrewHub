using BrewHub.Application.Contracts.Persistence;
using BrewHub.Application.Features.Commands.AddSaleToWholesaler;
using FluentValidation;
using MediatR;

namespace BrewHub.Application.Features.Commands
{
    public class AddSaleToWholesalerHandler : IRequestHandler<AddSaleToWholesalerCommand>
    {
        private readonly IWholesalerService _wholesalerService;

        public AddSaleToWholesalerHandler(IWholesalerService wholesalerService)
        {
            _wholesalerService = wholesalerService;
        }

        public async Task<Unit> Handle(AddSaleToWholesalerCommand request, CancellationToken cancellationToken)
        {
            // Validate the request
            new AddSaleToWholesalerCommandValidator().ValidateAndThrow(request);

            await _wholesalerService.AddSaleToWholesalerAsync(request.WholesalerId, request.BeerId, request.Quantity);
            return Unit.Value;
        }
    }
}
