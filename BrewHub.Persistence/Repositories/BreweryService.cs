using AutoMapper;
using BrewHub.Application.Contracts.Persistence;
using BrewHub.Application.Features.DtoModels;
using BrewHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewHub.Persistence.Repositories
{
    public class BreweryService : IBreweryService
    {
        private readonly BeerHubDbContext _dbContext;
        private readonly IMapper _mapper;

        public BreweryService(BeerHubDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BeerDto>> GetAllBeersByBreweryAsync(int breweryId)
        {
            var beers = await _dbContext.Beers
                .Where(b => b.BreweryId == breweryId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<BeerDto>>(beers);
        }

        public async Task<BeerDto> AddNewBeerAsync(int breweryId, BeerDto newBeerDto)
        {
            var brewery = await _dbContext.Breweries.FindAsync(breweryId);
            if (brewery == null)
            {
                // Handle the case where the specified brewery doesn't exist
                //throw new NotFoundException("Brewery not found.");
            }

            var newBeer = _mapper.Map<Beer>(newBeerDto);
            newBeer.BreweryId = breweryId;

            _dbContext.Beers.Add(newBeer);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<BeerDto>(newBeer);
        }

        public async Task DeleteBeerAsync(int beerId)
        {
            var beer = await _dbContext.Beers.FindAsync(beerId);
            if (beer == null)
            {
                // Handle the case where the specified beer doesn't exist
                //throw new NotFoundException("Beer not found.");
            }

            _dbContext.Beers.Remove(beer);
            await _dbContext.SaveChangesAsync();
        }
    }
}

