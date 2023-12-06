using BrewHub.Application.Features.DtoModels;

namespace BrewHub.Application.Contracts.Persistence
{
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
