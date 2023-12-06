using AutoMapper;
using BrewHub.Application.Contracts.Persistence;
using BrewHub.Application.Features.DtoModels;
using BrewHub.Domain.Entities;

namespace BrewHub.Persistence.Repositories
{
    public class QuoteService : IQuoteService
    {
        private readonly BeerHubDbContext _dbContext;
        private readonly IMapper _mapper;

        public QuoteService(BeerHubDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<QuoteDto> GenerateQuoteAsync(int wholesalerId, QuoteRequestDto requestDto)
        {
            // Implementation for generating a quote
            // Consider business rules and constraints

            // Example: Generating a quote based on the provided request
            var quote = new Quote
            {
                WholesalerId = wholesalerId,
                ClientId = requestDto.ClientId,
                // ... (populate other properties based on the request)
            };

            // Add quote details based on the request
            foreach (var detailDto in requestDto.QuoteDetailsDto)
            {
                var beer = await _dbContext.Beers.FindAsync(detailDto.BeerId);
                if (beer == null)
                {
                    // Handle the case where the specified beer doesn't exist
                    //throw new NotFoundException("Beer not found.");
                }

                // Validate other business rules and constraints as needed

                var quoteDetail = new QuoteDetail
                {
                    QuoteId = quote.QuoteId,
                    BeerId = detailDto.BeerId,
                    Quantity = detailDto.Quantity,
                    // ... (populate other properties based on the request)
                };

                quote.QuoteDetails.Add(quoteDetail);
            }

            await _dbContext.Quotes.AddAsync(quote);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<QuoteDto>(quote);
        }
    }
}

