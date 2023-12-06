namespace BrewHub.Domain.Entities
{
    public class QuoteDetail
    {
        public int QuoteDetailId { get; set; }
        public int QuoteId { get; set; }
        public Quote Quote { get; set; }

        public int BeerId { get; set; }
        public Beer Beer { get; set; }

        public int Quantity { get; set; }
        public decimal Discount { get; set; }
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
