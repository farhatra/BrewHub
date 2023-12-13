using AutoMapper;
using BrewHub.Application.Features.DtoModels;
using BrewHub.Application.Profiles;
using BrewHub.Persistence;
using BrewHub.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BrewHub.Test
{
    public class BreweryServiceTests
    {
        [Fact]
        public async Task AddNewBeerAsync_ValidData_ShouldAddNewBeer()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            var mapper = GetMapper();
            var breweryService = new BreweryService(dbContext, mapper);

            var breweryId = 1;
            var newBeerDto = new BeerDto { Name = "TestBeer", Type = "TestType", Price = 3.50m };

            // Act
            var result = await breweryService.AddNewBeerAsync(breweryId, newBeerDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(newBeerDto.Name, result.Name);
            Assert.Equal(newBeerDto.Type, result.Type);
            Assert.Equal(newBeerDto.Price, result.Price);
        }

        private static BeerHubDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<BeerHubDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new BeerHubDbContext(options);
        }

        private static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            return config.CreateMapper();
        }
    }
}