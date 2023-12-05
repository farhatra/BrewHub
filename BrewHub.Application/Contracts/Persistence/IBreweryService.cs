using BrewHub.Application.Features.DtoModels;
using BrewHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewHub.Application.Contracts.Persistence
{
    public interface IBreweryService
    {
        //IEnumerable<Beer> GetAllBeersByBrewery(int breweryId);
        //Beer AddNewBeer(int breweryId, Beer newBeer);
        //void DeleteBeer(int beerId);

        Task<IEnumerable<BeerDto>> GetAllBeersByBreweryAsync(int breweryId);
        Task<BeerDto> AddNewBeerAsync(int breweryId, BeerDto newBeerDto);
        Task DeleteBeerAsync(int beerId);
    }
    public interface IWholesalerService
    {
        //void AddSaleToWholesaler(int wholesalerId, int beerId, int quantity);
        //void UpdateRemainingQuantity(int wholesalerId, int beerId, int newQuantity);
        //Quote RequestQuote(int wholesalerId, QuoteRequest request);

        Task AddSaleToWholesalerAsync(int wholesalerId, int beerId, int quantity);
        Task UpdateRemainingQuantityAsync(int wholesalerId, int beerId, int newQuantity);
        Task<QuoteDto> RequestQuoteAsync(int wholesalerId, QuoteRequestDto requestDto);
    }
    public interface IQuoteService
    {
        //Quote GenerateQuote(int wholesalerId, QuoteRequest request);
        Task<QuoteDto> GenerateQuoteAsync(int wholesalerId, QuoteRequestDto requestDto);

    }
    //public class QuoteRequest
    //{
    //    public string ClientId { get; set; }
    //    public List<QuoteDetailRequest> QuoteDetails { get; set; }
    //}
    //public class QuoteDetailRequest
    //{
    //    public int BeerId { get; set; }
    //    public int Quantity { get; set; }
    //}

}
