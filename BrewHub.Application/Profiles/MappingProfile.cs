using AutoMapper;
using BrewHub.Application.Features.DtoModels;
using BrewHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewHub.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Beer, BeerDto>().ReverseMap();
            CreateMap<Wholesaler, WholesalerDto>().ReverseMap();
            CreateMap<Quote, QuoteDto>().ReverseMap();
            //CreateMap<QuoteRequest, QuoteRequestDto>().ReverseMap();

        }
    }
}
