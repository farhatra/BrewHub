namespace BrewHub.Domain.Entities
{
    public class Beer
    {
        public int BeerId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }

        public int BreweryId { get; set; }
        public Brewery Brewery { get; set; }

        public ICollection<WholesalerBeer> WholesalerBeers { get; set; }
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
