using BrewHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BrewHub.Persistence
{
    public class BeerHubDbContext : DbContext
    {
        public DbSet<Brewery> Breweries { get; set; }
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Wholesaler> Wholesalers { get; set; }
        public DbSet<WholesalerBeer> WholesalerBeers { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<QuoteDetail> QuoteDetails { get; set; }

        public BeerHubDbContext(DbContextOptions<BeerHubDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BeerHubDbContext).Assembly);

            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {

            // Seed Belgian breweries
            var belgianBreweries = new List<Brewery>{
                new Brewery { BreweryId = 1, Name = "Chimay Brewery", Location = "Chimay, Belgium" },
                new Brewery { BreweryId = 2, Name = "Westmalle Brewery", Location = "Westmalle, Belgium" },
                new Brewery { BreweryId = 3, Name = "Rochefort Brewery", Location = "Rochefort, Belgium" },
                new Brewery { BreweryId = 4, Name = "Duvel Moortgat Brewery", Location = "Puurs, Belgium" },
                new Brewery { BreweryId = 5, Name = "Achouffe Brewery", Location = "Achouffe, Belgium" },
                new Brewery { BreweryId = 6, Name = "St. Bernardus Brewery", Location = "Watou, Belgium" },
                new Brewery { BreweryId = 7, Name = "Brasserie de la Senne", Location = "Brussels, Belgium" }
            };

            modelBuilder.Entity<Brewery>().HasData(belgianBreweries);

            // Seed beers related to Belgian breweries
            var belgianBeers = new List<Beer>
    {
                new Beer { BeerId = 1, Name = "Chimay Blue", Type = "Trappist Ale", Price = 10.0m, BreweryId = 1 },
                new Beer { BeerId = 2, Name = "Chimay Red", Type = "Dubbel", Price = 8.0m, BreweryId = 1 },
                new Beer { BeerId = 3, Name = "Westmalle Tripel", Type = "Tripel", Price = 9.0m, BreweryId = 2 },
                new Beer { BeerId = 4, Name = "Rochefort 10", Type = "Quadrupel", Price = 12.0m, BreweryId = 3 },
                new Beer { BeerId = 5, Name = "Duvel", Type = "Strong Pale Ale", Price = 11.0m, BreweryId = 4 },
                new Beer { BeerId = 6, Name = "La Chouffe", Type = "Belgian Strong Ale", Price = 10.5m, BreweryId = 5 },
                new Beer { BeerId = 7, Name = "St. Bernardus Abt 12", Type = "Quadrupel", Price = 11.5m, BreweryId = 6 },
                new Beer { BeerId = 8, Name = "Brusseleir", Type = "Belgian Pale Ale", Price = 9.5m, BreweryId = 7 }
            };

            modelBuilder.Entity<Beer>().HasData(belgianBeers);

            // Seed wholesalers related to Belgian beers
            var belgianWholesalers = new List<Wholesaler>
            {
                new Wholesaler { WholesalerId = 1, Name = "Belgian Beer Distributors", Stock = 100 },
                new Wholesaler { WholesalerId = 2, Name = "Brewery Warehouse", Stock = 150 },
                new Wholesaler { WholesalerId = 3, Name = "Global Beverages", Stock = 120 },
                new Wholesaler { WholesalerId = 4, Name = "Hop Haven", Stock = 80 },
                new Wholesaler { WholesalerId = 5, Name = "Bier Bazaar", Stock = 200 },
                new Wholesaler { WholesalerId = 6, Name = "Beer Paradise", Stock = 170 },
                new Wholesaler { WholesalerId = 7, Name = "Eurobrew Imports", Stock = 130 }
            };

            modelBuilder.Entity<Wholesaler>().HasData(belgianWholesalers);

            // Seed relationships between wholesalers and beers
            var wholesalerBeers = new List<WholesalerBeer>
            {
                new WholesalerBeer { WholesalerId = 1, BeerId = 1, RemainingQuantity = 50 },
                new WholesalerBeer { WholesalerId = 1, BeerId = 2, RemainingQuantity = 75 },
                new WholesalerBeer { WholesalerId = 2, BeerId = 3, RemainingQuantity = 100 },
                new WholesalerBeer { WholesalerId = 3, BeerId = 4, RemainingQuantity = 60 },
                new WholesalerBeer { WholesalerId = 3, BeerId = 5, RemainingQuantity = 90 },
                new WholesalerBeer { WholesalerId = 4, BeerId = 6, RemainingQuantity = 110 },
                new WholesalerBeer { WholesalerId = 5, BeerId = 7, RemainingQuantity = 80 },
                new WholesalerBeer { WholesalerId = 6, BeerId = 8, RemainingQuantity = 120 }
            };

            modelBuilder.Entity<WholesalerBeer>().HasData(wholesalerBeers);

            // Seed quotes
            var quotes = new List<Quote>
            {
                new Quote { QuoteId = 1, WholesalerId = 1, ClientId = "Client1", TotalPrice = 200.0m, Summary = "Quote summary 1" },
                new Quote { QuoteId = 2, WholesalerId = 2, ClientId = "Client2", TotalPrice = 150.0m, Summary = "Quote summary 2" },
                new Quote { QuoteId = 3, WholesalerId = 3, ClientId = "Client3", TotalPrice = 180.0m, Summary = "Quote summary 3" }
            };

            modelBuilder.Entity<Quote>().HasData(quotes);

            // Seed quote details
            var quoteDetails = new List<QuoteDetail>
            {
                new QuoteDetail { QuoteDetailId = 1, QuoteId = 1, BeerId = 1, Quantity = 10, Discount = 0.0m },
                new QuoteDetail { QuoteDetailId = 2, QuoteId = 1, BeerId = 2, Quantity = 15, Discount = 5.0m },
                new QuoteDetail { QuoteDetailId = 3, QuoteId = 2, BeerId = 3, Quantity = 20, Discount = 10.0m },
                new QuoteDetail { QuoteDetailId = 4, QuoteId = 3, BeerId = 4, Quantity = 8, Discount = 2.0m },
                new QuoteDetail { QuoteDetailId = 5, QuoteId = 3, BeerId = 5, Quantity = 12, Discount = 4.0m }
            };

            modelBuilder.Entity<QuoteDetail>().HasData(quoteDetails);
        }

    }

}

