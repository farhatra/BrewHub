using AutoMapper;
using BrewHub.Application.Contracts.Persistence;
using BrewHub.Application.Features.DtoModels;
using BrewHub.Application.Features.Queries.RequestQuote;
using FluentValidation;
using MediatR;

namespace BrewHub.Application.Features.Queries
{
    public class RequestQuoteHandler : IRequestHandler<RequestQuoteQuery, QuoteDto>
    {
        private readonly IQuoteService _quoteService;
        private readonly IMapper _mapper;

        public RequestQuoteHandler(IQuoteService quoteService, IMapper mapper)
        {
            _quoteService = quoteService;
            _mapper = mapper;
        }

        //change RequestQuoteAsync to GenerateQuoteAsync based on the Interface
        public async Task<QuoteDto> Handle(RequestQuoteQuery request, CancellationToken cancellationToken)
        {
            // Validate the request
            var validator = new RequestQuoteCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
            {
                throw new Exceptions.ValidationException(validationResult);
            }

            var quote = await _quoteService.GenerateQuoteAsync(request.WholesalerId, request.RequestDto);
            return _mapper.Map<QuoteDto>(quote);
        }
    }
}
