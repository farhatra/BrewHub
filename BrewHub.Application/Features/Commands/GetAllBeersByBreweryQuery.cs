using AutoMapper;
using BrewHub.Application.Contracts.Persistence;
using BrewHub.Application.Features.DtoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewHub.Application.Features.Commands
{
    // Request and Handler for GetAllBeersByBreweryAsync
    public class GetAllBeersByBreweryQuery : IRequest<IEnumerable<BeerDto>>
    {
        public int BreweryId { get; set; }
    }

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

    // Request and Handler for AddNewBeerAsync
    public class AddNewBeerCommand : IRequest<BeerDto>
    {
        public int BreweryId { get; set; }
        public BeerDto NewBeerDto { get; set; }
    }

    public class AddNewBeerHandler : IRequestHandler<AddNewBeerCommand, BeerDto>
    {
        private readonly IBreweryService _breweryService;
        private readonly IMapper _mapper;

        public AddNewBeerHandler(IBreweryService breweryService, IMapper mapper)
        {
            _breweryService = breweryService;
            _mapper = mapper;
        }

        public async Task<BeerDto> Handle(AddNewBeerCommand request, CancellationToken cancellationToken)
        {
            var newBeer = await _breweryService.AddNewBeerAsync(request.BreweryId, request.NewBeerDto);
            return _mapper.Map<BeerDto>(newBeer);
        }
    }

    // Request and Handler for DeleteBeerAsync
    public class DeleteBeerCommand : IRequest
    {
        public int BeerId { get; set; }
    }

    public class DeleteBeerHandler : IRequestHandler<DeleteBeerCommand>
    {
        private readonly IBreweryService _breweryService;

        public DeleteBeerHandler(IBreweryService breweryService)
        {
            _breweryService = breweryService;
        }

        public async Task<Unit> Handle(DeleteBeerCommand request, CancellationToken cancellationToken)
        {
            await _breweryService.DeleteBeerAsync(request.BeerId);
            return Unit.Value;
        }
    }

    // Request and Handler for AddSaleToWholesalerAsync
    public class AddSaleToWholesalerCommand : IRequest
    {
        public int WholesalerId { get; set; }
        public int BeerId { get; set; }
        public int Quantity { get; set; }
    }

    public class AddSaleToWholesalerHandler : IRequestHandler<AddSaleToWholesalerCommand>
    {
        private readonly IWholesalerService _wholesalerService;

        public AddSaleToWholesalerHandler(IWholesalerService wholesalerService)
        {
            _wholesalerService = wholesalerService;
        }

        public async Task<Unit> Handle(AddSaleToWholesalerCommand request, CancellationToken cancellationToken)
        {
            await _wholesalerService.AddSaleToWholesalerAsync(request.WholesalerId, request.BeerId, request.Quantity);
            return Unit.Value;
        }
    }

    // Request and Handler for UpdateRemainingQuantityAsync
    public class UpdateRemainingQuantityCommand : IRequest
    {
        public int WholesalerId { get; set; }
        public int BeerId { get; set; }
        public int NewQuantity { get; set; }
    }

    public class UpdateRemainingQuantityHandler : IRequestHandler<UpdateRemainingQuantityCommand>
    {
        private readonly IWholesalerService _wholesalerService;

        public UpdateRemainingQuantityHandler(IWholesalerService wholesalerService)
        {
            _wholesalerService = wholesalerService;
        }

        public async Task<Unit> Handle(UpdateRemainingQuantityCommand request, CancellationToken cancellationToken)
        {
            await _wholesalerService.UpdateRemainingQuantityAsync(request.WholesalerId, request.BeerId, request.NewQuantity);
            return Unit.Value;
        }
    }

    // Request and Handler for RequestQuoteAsync
    public class RequestQuoteQuery : IRequest<QuoteDto>
    {
        public int WholesalerId { get; set; }
        public QuoteRequestDto RequestDto { get; set; }
    }

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
            var quote = await _quoteService.GenerateQuoteAsync(request.WholesalerId, request.RequestDto);
            return _mapper.Map<QuoteDto>(quote);
        }
    }
}
