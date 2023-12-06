using AutoMapper;
using BrewHub.Application.Contracts.Persistence;
using BrewHub.Application.Features.DtoModels;
using BrewHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrewHub.Persistence.Repositories
{
    public class WholesalerService : IWholesalerService
    {
        private readonly BeerHubDbContext _dbContext;
        private readonly IMapper _mapper;

        public WholesalerService(BeerHubDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task AddSaleToWholesalerAsync(int wholesalerId, int beerId, int quantity)
        {
            var wholesaler = await _dbContext.Wholesalers
                .Include(w => w.WholesalerBeers)
                .FirstOrDefaultAsync(w => w.WholesalerId == wholesalerId);

            var beer = await _dbContext.Beers.FindAsync(beerId);

            if (wholesaler == null || beer == null)
            {
                // Handle the case where the specified wholesaler or beer doesn't exist
                //throw new NotFoundException("Wholesaler or Beer not found.");
            }

            var wholesalerBeer = wholesaler.WholesalerBeers.FirstOrDefault(wb => wb.BeerId == beerId);
            if (wholesalerBeer == null)
            {
                // Handle the case where the specified beer is not in the wholesaler's stock
                //throw new BusinessException("Beer is not available in wholesaler's stock.");
            }

            if (wholesalerBeer.RemainingQuantity < quantity)
            {
                // Handle the case where the requested quantity exceeds the remaining stock
                //throw new BusinessException("Insufficient stock.");
            }

            // Update remaining quantity
            wholesalerBeer.RemainingQuantity -= quantity;
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRemainingQuantityAsync(int wholesalerId, int beerId, int newQuantity)
        {
            var wholesalerBeer = await _dbContext.WholesalerBeers
                .FirstOrDefaultAsync(wb => wb.WholesalerId == wholesalerId && wb.BeerId == beerId);

            if (wholesalerBeer == null)
            {
                // Handle the case where the specified wholesaler beer doesn't exist
                //throw new NotFoundException("Wholesaler Beer not found.");
            }

            wholesalerBeer.RemainingQuantity = newQuantity;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<QuoteDto> RequestQuoteAsync(int wholesalerId, QuoteRequestDto requestDto)
        {
            // Implementation for requesting a quote
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

