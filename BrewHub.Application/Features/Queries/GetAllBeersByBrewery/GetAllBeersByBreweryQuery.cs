using BrewHub.Application.Features.DtoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewHub.Application.Features.Queries
{
    // Request and Handler for GetAllBeersByBreweryAsync
    public class GetAllBeersByBreweryQuery : IRequest<IEnumerable<BeerDto>>
    {
        public int BreweryId { get; set; }
    }
}
