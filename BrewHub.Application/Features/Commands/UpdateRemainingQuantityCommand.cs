using MediatR;

namespace BrewHub.Application.Features.Commands
{
    // Request and Handler for UpdateRemainingQuantityAsync
    public class UpdateRemainingQuantityCommand : IRequest
    {
        public int WholesalerId { get; set; }
        public int BeerId { get; set; }
        public int NewQuantity { get; set; }
    }
}
