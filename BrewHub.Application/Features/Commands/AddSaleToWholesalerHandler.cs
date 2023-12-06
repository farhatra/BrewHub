using BrewHub.Application.Contracts.Persistence;
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
            await _wholesalerService.AddSaleToWholesalerAsync(request.WholesalerId, request.BeerId, request.Quantity);
            return Unit.Value;
        }
    }
}
