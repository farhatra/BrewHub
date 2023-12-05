using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrewHub.Application.Contracts.Persistence;
using BrewHub.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BrewHub.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BeerHubDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BeerHubDbContextConnectionString")));

            //services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            //one instance is created per request
            services.AddScoped<IBreweryService, BreweryService>();
            services.AddScoped<IWholesalerService, WholesalerService>();
            services.AddScoped<IQuoteService, QuoteService>();

            return services;
        }
    }
}
