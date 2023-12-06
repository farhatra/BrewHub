using BrewHub.Application.Features.DtoModels;

namespace BrewHub.Application.Contracts.Persistence
{
    public interface IWholesalerService
    {
        //void AddSaleToWholesaler(int wholesalerId, int beerId, int quantity);
        //void UpdateRemainingQuantity(int wholesalerId, int beerId, int newQuantity);
        //Quote RequestQuote(int wholesalerId, QuoteRequest request);

        Task AddSaleToWholesalerAsync(int wholesalerId, int beerId, int quantity);
        Task UpdateRemainingQuantityAsync(int wholesalerId, int beerId, int newQuantity);
        Task<QuoteDto> RequestQuoteAsync(int wholesalerId, QuoteRequestDto requestDto);
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
