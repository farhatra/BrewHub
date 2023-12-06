namespace BrewHub.Domain.Entities
{
    public class Wholesaler
    {
        public int WholesalerId { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }

        public ICollection<WholesalerBeer> WholesalerBeers { get; set; }
        public ICollection<Quote> Quotes { get; set; }
    }

    //public class QuoteRequest
    //{
    //    public string ClientId { get; set; }
    //    public List<QuoteDetailRequest> QuoteDetails { get; set; }
    //}
    //// DTOs for QuoteDetailRequest
    //public class QuoteDetailRequest
    //{
    //    public int BeerId { get; set; }
    //    public int Quantity { get; set; }
    //}
}
