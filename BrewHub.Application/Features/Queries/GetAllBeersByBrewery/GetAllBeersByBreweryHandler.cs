using AutoMapper;
using BrewHub.Application.Contracts.Persistence;
using BrewHub.Application.Features.DtoModels;
using MediatR;

namespace BrewHub.Application.Features.Queries
{
    public class GetAllBeersByBreweryHandler : IRequestHandler<GetAllBeersByBreweryQuery, IEnumerable<BeerDto>>
    {
        private readonly IBreweryService _breweryService;
        private readonly IMapper _mapper;

        public GetAllBeersByBreweryHandler(IBreweryService breweryService, IMapper mapper)
        {
            _breweryService = breweryService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BeerDto>> Handle(GetAllBeersByBreweryQuery request, CancellationToken cancellationToken)
        {
            var beers = await _breweryService.GetAllBeersByBreweryAsync(request.BreweryId);
            return _mapper.Map<IEnumerable<BeerDto>>(beers);
        }
    }
}
