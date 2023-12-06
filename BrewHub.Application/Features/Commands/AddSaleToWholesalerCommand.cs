using MediatR;

namespace BrewHub.Application.Features.Commands
{
    // Request and Handler for AddSaleToWholesalerAsync
    public class AddSaleToWholesalerCommand : IRequest
    {
        public int WholesalerId { get; set; }
        public int BeerId { get; set; }
        public int Quantity { get; set; }
    }
}
