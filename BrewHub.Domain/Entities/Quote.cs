namespace BrewHub.Domain.Entities
{
    public class Quote
    {
        public int QuoteId { get; set; }
        public int WholesalerId { get; set; }
        public Wholesaler Wholesaler { get; set; }
        public string ClientId { get; set; }
        public decimal TotalPrice { get; set; }
        public string Summary { get; set; }

        public ICollection<QuoteDetail> QuoteDetails { get; set; }
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
