using BrewHub.Application.Features.DtoModels;
using MediatR;

namespace BrewHub.Application.Features.Queries
{
    // Request and Handler for RequestQuoteAsync
    public class RequestQuoteQuery : IRequest<QuoteDto>
    {
        public int WholesalerId { get; set; }
        public QuoteRequestDto RequestDto { get; set; }
    }
}
