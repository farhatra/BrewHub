using AutoMapper;
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
    public class WholesalerServiceTests
    {
        [Fact]
        public async Task AddSaleToWholesalerAsync_ValidData_ShouldAddSaleToWholesaler()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            var mapper = GetMapper();
            var wholesalerService = new WholesalerService(dbContext, mapper);

            var wholesalerId = 1;
            var beerId = 1;
            var quantity = 5;

            // Act
            await wholesalerService.AddSaleToWholesalerAsync(wholesalerId, beerId, quantity);

            // Assert
            var wholesaler = await dbContext.Wholesalers.FindAsync(wholesalerId);
            var wholesalerBeer = wholesaler.WholesalerBeers.FirstOrDefault(wb => wb.BeerId == beerId);

            Assert.NotNull(wholesalerBeer);
            Assert.Equal(10 - quantity, wholesalerBeer.RemainingQuantity);
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

