namespace BrewHub.Domain.Entities
{
    public class WholesalerBeer
    {
        public int WholesalerId { get; set; }
        public Wholesaler Wholesaler { get; set; }

        public int BeerId { get; set; }
        public Beer Beer { get; set; }

        public int RemainingQuantity { get; set; }
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
