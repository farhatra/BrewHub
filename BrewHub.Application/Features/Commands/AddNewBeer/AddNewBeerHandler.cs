﻿using AutoMapper;
using BrewHub.Application.Contracts.Persistence;
using BrewHub.Application.Features.Commands.AddNewBeer;
using BrewHub.Application.Features.DtoModels;
using FluentValidation;
using MediatR;

namespace BrewHub.Application.Features.Commands
{
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
            // Validate the request
            new AddNewBeerCommandValidator().ValidateAndThrow(request); 

            var newBeer = await _breweryService.AddNewBeerAsync(request.BreweryId, request.NewBeerDto);
            return _mapper.Map<BeerDto>(newBeer);
        }
    }
}
